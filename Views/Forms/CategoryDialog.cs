using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class CategoryDialog : Form
    {
        public CategoryDialog()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
        }

        public CategoryDialog(CategoryResponseDto categoryResponseDto)
        {
            InitializeComponent();
            txtCategoryName.Text = categoryResponseDto.Name;
            txtDescription.Text = categoryResponseDto.Description;
            cbType.SelectedItem = categoryResponseDto.Type.ToString();
            btnSubmit.Text = "Update";
            heading1.Title = "Update Category";

        }

        public CreateCategoryDto GetData()
        {
            var categoryDto = new CreateCategoryDto();
            categoryDto.Name = txtCategoryName.Text;
            categoryDto.Description = txtDescription.Text;
            categoryDto.Type = Enum.Parse<TransactionType>(cbType.SelectedItem.ToString().ToUpper() ?? string.Empty);
            return categoryDto;
        }

        public UpdateCategoryDto GetUpdateData()
        {
            var categoryDto = new UpdateCategoryDto();
            categoryDto.Name = txtCategoryName.Text;
            categoryDto.Description = txtDescription.Text;
            categoryDto.Type = Enum.Parse<TransactionType>(cbType.SelectedItem.ToString().ToUpper() ?? string.Empty);
            return categoryDto;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
