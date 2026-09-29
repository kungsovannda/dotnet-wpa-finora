using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Categories;
using PersonalExpenseTracker.Views.Data;
using PersonalExpenseTracker.Views.UI;
using PersonalExpenseTracker.Views.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class CategoryControl : UserControl, IRefreshablePage
    {
        private readonly CategoryController _controller;
        private readonly DataChangeNotifier _changes;

        /// <summary>Guards against a refresh that somehow triggers another one.</summary>
        private bool _refreshing;

        public CategoryControl(CategoryController controller, DataChangeNotifier changes)
        {
            _controller = controller;
            _changes = changes;
            InitializeComponent();
            BackColor = Colors.Background;

            _changes.Changed += Changes_Changed;
            Disposed += CategoryControl_Disposed;
        }

        /// <summary>
        /// Unhooks from the shared notifier. Subscribing to Disposed rather than
        /// overriding Dispose keeps the designer's own partial out of the way.
        /// </summary>
        private void CategoryControl_Disposed(object? sender, EventArgs e)
        {
            _changes.Changed -= Changes_Changed;
        }

        private void Changes_Changed(object? sender, DataChangedEventArgs e)
        {
            if (IsDisposed || Disposing)
                return;

            // The cards only depend on categories, so a transaction write - which
            // can never add or rename one - is not worth a rebuild.
            if (!e.Includes(DataChange.Categories))
                return;

            if (Visible)
                RefreshData();
        }

        /// <summary>
        /// Rebuilds the card grid. Single load path: the first show, a revisit
        /// and the page's own create/edit/delete all come through here.
        /// </summary>
        public void RefreshData()
        {
            if (_refreshing || IsDisposed || !IsHandleCreated)
                return;

            _refreshing = true;
            try
            {
                LoadCategories();
            }
            finally
            {
                _refreshing = false;
            }
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {
            // Load fires once per instance, so this is only the first show.
            // Every later visit goes through MainForm -> RefreshData.
            RefreshData();
        }

        private void LoadCategories()
        {
            List<CategoryResponseDto> categories;
            try
            {
                categories = _controller.GetAllCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            flow.SuspendLayout();

            // Rebuild the card grid. Disposing removes each card from the panel.
            while (flow.Controls.Count > 0)
                flow.Controls[0].Dispose();

            foreach (var category in categories)
            {
                var card = new CategoryCard
                {
                    Id = category.Id,
                    CategoryName = category.Name,
                    DescriptionText = category.Description,
                    EmojiGlyph = category.Emoji,
                    IsIncome = category.Type == TransactionType.INCOME
                };

                card.MenuRequested += Card_MenuRequested;
                flow.Controls.Add(card);
            }

            flow.ResumeLayout();

            bool hasItems = categories.Count > 0;
            flow.Visible = hasItems;
            empty.Visible = !hasItems;
        }

        private void Card_MenuRequested(object? sender, CategoryActionEventArgs e)
        {
            if (sender is CategoryCard card)
                ShowActionsMenu(card, e.Id);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            var categoryDialog = new CategoryDialog();
            if (categoryDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _controller.CreateCategory(categoryDialog.GetData());
                    _changes.Notify(DataChange.Categories);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowActionsMenu(CategoryCard card, long id)
        {
            var menu = new ContextMenuStrip();

            var editItem = new ToolStripMenuItem("Edit", Resources.Resources.edit);
            var deleteItem = new ToolStripMenuItem("Delete", Resources.Resources.trash);

            editItem.Click += (_, _) => EditCategory(id);
            deleteItem.Click += (_, _) => DeleteCategory(id);

            menu.Items.Add(editItem);
            menu.Items.Add(deleteItem);

            var location = new Point(card.Width - Theme.Space2, card.Height - Theme.Space2);
            menu.Show(card, location);
        }

        private void EditCategory(long id)
        {
            var category = _controller.GetCategory(id);
            var categoryDialog = new CategoryDialog(category);
            if (categoryDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var update = categoryDialog.GetUpdateData();
                    update.Id = id;
                    _controller.UpdateCategory(update);
                    _changes.Notify(DataChange.Categories);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteCategory(long id)
        {
            var category = _controller.GetCategory(id);
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the category '{category.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.DeleteCategory(id);
                    _changes.Notify(DataChange.Categories);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
