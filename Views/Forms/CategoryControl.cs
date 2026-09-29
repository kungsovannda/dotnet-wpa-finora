using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Categories;
using PersonalExpenseTracker.Views.UI;
using PersonalExpenseTracker.Views.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class CategoryControl : UserControl
    {
        private readonly CategoryController _controller;

        public CategoryControl(CategoryController controller)
        {
            _controller = controller;
            InitializeComponent();
            BackColor = Colors.Background;
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {
            LoadCategories();
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
                    LoadCategories();
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
                    LoadCategories();
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
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
