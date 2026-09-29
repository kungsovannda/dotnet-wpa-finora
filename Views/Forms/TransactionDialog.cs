using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Categories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class TransactionDialog : Form
    {
        private readonly CategoryController _categoryController;
        private List<CategoryResponseDto> _categories = new List<CategoryResponseDto>();

        /// <summary>
        /// The amount the user typed. Captured by <see cref="btnSubmit_Click"/>
        /// only once it has parsed and passed the greater-than-zero check, so
        /// <see cref="GetData"/> never reports a figure the user did not enter.
        /// </summary>
        private decimal _amount;

        public TransactionDialog(CategoryController categoryController)
        {
            _categoryController = categoryController;
            InitializeComponent();
        }

        public CreateTransactionDto GetData()
        {
            var data = new CreateTransactionDto
            {
                Amount = _amount,
                Description = txtDescription.Text
            };

            if (cbCategory.SelectedItem is CategoryResponseDto selectedCategory)
            {
                data.CategoryId = selectedCategory.Id;
                data.Type = selectedCategory.Type;
            }

            return data;
        }

        private void TransactionDialog_Load(object sender, EventArgs e)
        {
            _categories = _categoryController.GetAllCategories();

            var bindingSource = new BindingSource(_categories, string.Empty);
            cbCategory.DataSource = bindingSource;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";

            if (_categories.Count > 0)
            {
                cbCategory.SelectedIndex = 0;
            }

            // The amount is the one value the user must supply, so start there.
            txtAmount.FocusInput();
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            // Validate before closing. Closing first would throw the typed
            // values away and leave the user to retype all of them.
            if (!TryReadAmount(out decimal amount))
                return;

            _amount = amount;

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Reads the amount field. Accepts what a person would type for money -
        /// grouping separators, a currency symbol, either decimal separator -
        /// and mirrors the service rule that the amount must be above zero.
        /// </summary>
        private bool TryReadAmount(out decimal amount)
        {
            string raw = (txtAmount.Text ?? string.Empty).Trim();

            if (raw.Length == 0)
                return RejectAmount("Enter an amount before saving.", out amount);

            amount = ParseAmount(raw);

            if (amount == 0m)
            {
                bool isANumber = decimal.TryParse(
                    raw, NumberStyles.Currency, CultureInfo.CurrentCulture, out _);

                return RejectAmount(
                    isANumber
                        ? "The amount must be greater than zero."
                        : $"\"{raw}\" is not a valid amount.",
                    out amount);
            }

            return true;
        }

        /// <summary>
        /// Parses a typed amount, returning zero for anything unusable. Zero is
        /// deliberately the failure value: it is the one figure the service
        /// rejects anyway, so bad input can never become a valid transaction.
        /// </summary>
        private decimal ParseAmount(string raw)
        {
            raw = (raw ?? string.Empty).Trim();

            if (raw.Length == 0)
                return 0m;

            bool parsed =
                decimal.TryParse(raw, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal amount) ||
                decimal.TryParse(raw, NumberStyles.Currency, CultureInfo.InvariantCulture, out amount);

            return parsed && amount > 0m ? amount : 0m;
        }

        /// <summary>Reports an unusable amount and returns false for TryReadAmount.</summary>
        private bool RejectAmount(string message, out decimal amount)
        {
            amount = 0m;
            ShowError(message);
            txtAmount.FocusInput();
            return false;
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbCategory.SelectedItem is CategoryResponseDto selectedCategory)
            {
                // Mirrors the category's own type. The field is read-only, so
                // the only way it can change is by picking a different category.
                txtType.Text = selectedCategory.Type.ToString();
            }
        }

        /// <summary>
        /// Single error surface for this dialog, matching how the rest of the
        /// app reports a failed write. Passing the owner keeps the box in front
        /// of this modal form instead of letting it open behind it.
        /// </summary>
        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
