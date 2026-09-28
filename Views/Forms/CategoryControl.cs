using PersonalExpenseTracker.Features.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgv.Columns[e.ColumnIndex].Name != "Actions")
                return;

            var id = (long) dgv.Rows[e.RowIndex].Cells["Id"].Value;

            ShowActionsMenu(id, e.RowIndex);
        }
        

        private void LoadCategories()
        {
            var categories = _controller.GetAllCategories();
            dgv.DataSource = categories;
            dgv.Columns["Id"].DisplayIndex = 0;
            dgv.Columns["Name"].DisplayIndex = 1;
            dgv.Columns["Type"].DisplayIndex = 2;
            dgv.Columns["Description"].DisplayIndex = 3;
            dgv.Columns["CreatedAt"].DisplayIndex = 4;
            dgv.Columns["Actions"].DisplayIndex = 5;
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {
            var actionsColumn = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                Text = "⋮",
                UseColumnTextForButtonValue = true
            };

            dgv.Columns.Add(actionsColumn);
            LoadCategories();
        }

        private void button1_Click(object sender, EventArgs e)
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
                ;
            }
        }

        private void ShowActionsMenu(long id, int rowIndex)
        {
            var menu = new ContextMenuStrip();

            var editItem = new ToolStripMenuItem("Edit", Resources.Resources.edit);
            var deleteItem = new ToolStripMenuItem("Delete", Resources.Resources.trash);

            editItem.Click += (_, _) => EditCategory(id);
            deleteItem.Click += (_, _) => DeleteCategory(id);

            menu.Items.Add(editItem);
            menu.Items.Add(deleteItem);

            var cellRect = dgv.GetCellDisplayRectangle(
                dgv.Columns["Actions"].Index,
                rowIndex,
                true
            );

            var location = new Point(
                cellRect.Right,
                cellRect.Bottom
            );

            menu.Show(dgv, location);
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
        
        private void DeleteCategory(long id) {
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
