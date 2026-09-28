using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Categories;
using PersonalExpenseTracker.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class TransactionDialog : Form
    {
        private readonly CategoryController _categoryController;
        private List<CategoryResponseDto> _categories;

        public TransactionDialog(CategoryController categoryController)
        {
            _categoryController = categoryController;
            InitializeComponent();
        }

        public CreateTransactionDto GetData()
        {
            var data = new CreateTransactionDto();

            if (cbCategory.SelectedItem is CategoryResponseDto selectedCategory)
            {
                data.CategoryId = selectedCategory.Id;
                data.Type = selectedCategory.Type;
            }

            data.Description = txtDescription.Text;
            data.Amount = 100;

            return data;
        }

        private void TransactionDialog_Load(object sender, EventArgs e)
        {
            _categories = _categoryController.GetAllCategories();

            var bindingSource = new BindingSource(_categories, null);
            cbCategory.DataSource = bindingSource;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";

            if (_categories.Count > 0)
            {
                cbCategory.SelectedIndex = 0;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem is CategoryResponseDto selectedCategory)
            {
                cbType.SelectedItem = selectedCategory.Type.ToString();
            }
        }
    }
}
