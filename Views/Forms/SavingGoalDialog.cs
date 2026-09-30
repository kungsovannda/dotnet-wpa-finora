using System;
using System.Windows.Forms;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Views.UI;
using PersonalExpenseTracker.Views.UI.Controls;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// Create or edit a saving goal. The target amount is captured on submit
    /// rather than read from the field on demand, so a value the user has not
    /// finished typing can never reach the service.
    /// </summary>
    public partial class SavingGoalDialog : Form
    {
        private decimal _targetAmount;

        private SavingGoalResponseDto? _existing;

        public SavingGoalDialog()
        {
            InitializeComponent();
        }

        public SavingGoalDialog(SavingGoalResponseDto goal)
        {
            _existing = goal;
            InitializeComponent();

            txtName.Text = goal.Name;
            txtDescription.Text = goal.Description;
            txtEmoji.Glyph = goal.Emoji;
            dtTargetDate.Value = goal.TargetDate;
            // Shown formatted so the edit form opens with something the user
            // recognises rather than a bare number.
            txtTargetAmount.Text = goal.TargetAmount.ToString("0.00");
            _targetAmount = goal.TargetAmount;

            btnSubmit.Caption = "Save";
            btnSubmit.Text = "Save";
            heading1.Title = "Edit Saving Goal";
            heading1.description = "Update the target, deadline or details";
        }

        public CreateSavingGoalDto GetData()
        {
            return new CreateSavingGoalDto
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Emoji = Emoji.Normalize(txtEmoji.Glyph),
                TargetAmount = _targetAmount,
                TargetDate = dtTargetDate.Value
            };
        }

        public UpdateSavingGoalDto GetUpdateData()
        {
            return new UpdateSavingGoalDto
            {
                Id = _existing?.Id ?? 0,
                Name = txtName.Text,
                Description = txtDescription.Text,
                Emoji = Emoji.Normalize(txtEmoji.Glyph),
                TargetAmount = _targetAmount,
                TargetDate = dtTargetDate.Value,
                IsArchived = _existing?.IsArchived ?? false
            };
        }

        private void SavingGoalDialog_Load(object sender, EventArgs e)
        {
            txtName.FocusInput();
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            // Validate before closing: closing first would throw the typed
            // values away and leave the user to retype all of them.
            if (!TryReadTargetAmount())
                return;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowError("Enter a name for the goal.");
                txtName.FocusInput();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool TryReadTargetAmount()
        {
            if (MoneyInput.TryRead(txtTargetAmount, "a target amount", out decimal amount, out string error))
            {
                _targetAmount = amount;
                return true;
            }

            ShowError(error);
            txtTargetAmount.FocusInput();
            return false;
        }

        private void txtEmoji_Click(object? sender, EventArgs e)
        {
            using var picker = new EmojiPickerDialog();
            if (picker.ShowDialog(this) == DialogResult.OK)
                txtEmoji.Glyph = picker.SelectedGlyph;
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
