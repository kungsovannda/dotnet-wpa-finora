using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Views.UI;
using System;
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
            txtEmoji.Glyph = categoryResponseDto.Emoji;
            btnSubmit.Text = "Update";
            heading1.Title = "Update Category";
        }

        public CreateCategoryDto GetData()
        {
            var categoryDto = new CreateCategoryDto();
            categoryDto.Name = txtCategoryName.Text;
            categoryDto.Description = txtDescription.Text;
            categoryDto.Type = Enum.Parse<TransactionType>(cbType.SelectedItem?.ToString()?.ToUpper() ?? string.Empty);
            categoryDto.Emoji = Emoji.Normalize(txtEmoji.Glyph);
            return categoryDto;
        }

        public UpdateCategoryDto GetUpdateData()
        {
            var categoryDto = new UpdateCategoryDto();
            categoryDto.Name = txtCategoryName.Text;
            categoryDto.Description = txtDescription.Text;
            categoryDto.Type = Enum.Parse<TransactionType>(cbType.SelectedItem?.ToString()?.ToUpper() ?? string.Empty);
            categoryDto.Emoji = Emoji.Normalize(txtEmoji.Glyph);
            return categoryDto;
        }

        private void txtEmoji_Click(object? sender, EventArgs e)
        {
            using var picker = new EmojiPickerDialog();
            if (picker.ShowDialog(this) == DialogResult.OK)
                txtEmoji.Glyph = picker.SelectedGlyph;
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
