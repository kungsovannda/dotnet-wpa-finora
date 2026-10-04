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
        /// <summary>Upper bound on the grid, so a huge window is not a card wall.</summary>
        private const int MaxColumns = 8;

        private readonly CategoryController _controller;
        private readonly DataChangeNotifier _changes;

        /// <summary>
        /// The cards currently in the grid, in the order they were loaded. Held
        /// so a resize can re-flow the existing cards instead of rebuilding them.
        /// </summary>
        private readonly List<CategoryCard> _cards = new();

        /// <summary>Guards against a refresh that somehow triggers another one.</summary>
        private bool _refreshing;

        /// <summary>Guards the re-flow against the layout pass it triggers itself.</summary>
        private bool _layingOut;

        public CategoryControl(CategoryController controller, DataChangeNotifier changes)
        {
            _controller = controller;
            _changes = changes;
            InitializeComponent();
            BackColor = Colors.Background;

            grid.SizeChanged += Grid_SizeChanged;

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
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            grid.SuspendLayout();

            // Rebuild the card grid. Disposing removes each card from the panel.
            while (grid.Controls.Count > 0)
                grid.Controls[0].Dispose();

            _cards.Clear();

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
                _cards.Add(card);
            }

            grid.ResumeLayout(false);

            bool hasItems = categories.Count > 0;
            grid.Visible = hasItems;
            empty.Visible = !hasItems;

            LayoutCards();
        }

        /// <summary>
        /// The grid re-flows when the page is resized, so the last column always
        /// ends flush with the right edge instead of leaving a ragged gap.
        /// </summary>
        private void Grid_SizeChanged(object? sender, EventArgs e) => LayoutCards();

        /// <summary>
        /// Lays the cards out as a responsive grid: as many equal columns as the
        /// page can hold at a comfortable card width, and no leftover strip on the
        /// right. The cards themselves are reused - only their cells change.
        /// </summary>
        private void LayoutCards()
        {
            if (_layingOut || IsDisposed || _cards.Count == 0)
                return;

            int available = grid.ClientSize.Width;
            if (available <= 0)
                return;

            _layingOut = true;
            try
            {
                int gap = CategoryCard.Gap;
                int columns = ColumnCountFor(available, gap);
                int cardWidth = (available - (columns - 1) * gap) / columns;

                // Whole pixels do not divide evenly, so the leftover goes in front
                // of the last card: every card keeps the same width and the row
                // still ends flush with the right edge.
                int remainder = available - (columns * cardWidth + (columns - 1) * gap);

                int cardHeight = Theme.Scaled(CategoryCard.CardHeight, Theme.ScaleOf(this));
                int pitch = cardHeight + gap;
                int rows = (_cards.Count + columns - 1) / columns;

                grid.SuspendLayout();

                // The counts are set explicitly: the styles and the cells are
                // rebuilt from scratch on every pass, and a table that only grows
                // itself would keep the previous pass's shape.
                grid.ColumnCount = columns;
                // One row past the end, filled by nothing, is what lets the table be
                // exactly as tall as the cards need and the page scroll it. Without
                // it a percent row would stretch the cards to the page.
                grid.RowCount = rows + 1;
                grid.ColumnStyles.Clear();
                grid.RowStyles.Clear();

                for (int column = 0; column < columns; column++)
                {
                    // The last column carries the leftover pixels as leading room
                    // so the row ends exactly on the page's right edge.
                    int width = column == columns - 1
                        ? cardWidth + remainder
                        : cardWidth + gap;

                    grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, width));
                }

                for (int row = 0; row < rows; row++)
                    grid.RowStyles.Add(new RowStyle(SizeType.Absolute, pitch));

                // The trailing row: the room the cards do not need.
                grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                for (int i = 0; i < _cards.Count; i++)
                {
                    var card = _cards[i];
                    int column = i % columns;
                    int row = i / columns;
                    bool last = column == columns - 1;

                    // The gap is dropped between the last two columns and put in
                    // front of the last card instead, so every card is the same
                    // width and the row still ends on the edge.
                    card.Margin = last
                        ? new Padding(remainder, 0, 0, gap)
                        : new Padding(0, 0, gap, gap);

                    if (grid.Controls.Contains(card))
                    {
                        if (grid.GetColumn(card) != column || grid.GetRow(card) != row)
                        {
                            grid.Controls.Remove(card);
                            grid.Controls.Add(card, column, row);
                        }
                    }
                    else
                    {
                        grid.Controls.Add(card, column, row);
                    }
                }

                // The table is exactly as tall as its rows, so the page - which is
                // the scrolling host - decides whether a scrollbar is needed. A
                // grid that scrolled itself would feed its own scrollbar back into
                // the column count and never settle.
                int height = rows * pitch;
                if (grid.Height != height)
                    grid.Height = height;

                grid.ResumeLayout(true);
            }
            finally
            {
                _layingOut = false;
            }
        }

        /// <summary>
        /// The most columns that still give every card a sensible width. Walks
        /// down from the widest grid so the answer is stable as the page resizes.
        /// </summary>
        private static int ColumnCountFor(int available, int gap)
        {
            for (int columns = MaxColumns; columns >= 2; columns--)
            {
                int width = (available - (columns - 1) * gap) / columns;
                if (width >= CategoryCard.MinWidth && width <= CategoryCard.MaxWidth)
                    return columns;
            }

            // Too narrow for two cards side by side: one full width card.
            if (available < (CategoryCard.MinWidth + gap) * 2)
                return 1;

            // Too wide for the band - a very large monitor. The most columns the
            // grid is allowed, which gives big cards rather than one absurd one.
            return MaxColumns;
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
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Anchored under the row's menu button at the top-right of the card.
            var location = new Point(card.Width - Theme.Space5, Theme.Space4);
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
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteCategory(long id)
        {
            var category = _controller.GetCategory(id);
            DialogResult result = MessageBox.Show(this, $"Are you sure you want to delete the category '{category.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.DeleteCategory(id);
                    _changes.Notify(DataChange.Categories);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
