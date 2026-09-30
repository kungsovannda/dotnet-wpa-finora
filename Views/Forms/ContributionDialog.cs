using System;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// Records a deposit towards a goal. The heading spells out what the amount
    /// adds up to, so it is never ambiguous whether the goal is asking for a
    /// transfer or a purchase.
    /// </summary>
    public partial class ContributionDialog : Form
    {
        private readonly SavingGoalResponseDto _goal;
        private decimal _amount;

        public ContributionDialog(SavingGoalResponseDto goal)
        {
            _goal = goal;
            InitializeComponent();

            heading1.Title = $"Add money to {goal.Name}";
            heading1.description = string.Format(
                CultureInfo.CurrentCulture,
                "{0} saved of {1} so far.",
                goal.CurrentAmount.ToString("C", CultureInfo.CurrentCulture),
                goal.TargetAmount.ToString("C", CultureInfo.CurrentCulture));

            btnSubmit.Caption = "Add Money";
            btnSubmit.Text = "Add Money";
        }

        public AddGoalContributionDto GetData(long savingGoalId)
        {
            return new AddGoalContributionDto
            {
                SavingGoalId = savingGoalId,
                Amount = _amount,
                Date = dtDate.Value,
                Note = txtNote.Text
            };
        }

        private void ContributionDialog_Load(object sender, EventArgs e)
        {
            txtAmount.FocusInput();
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            // Validate before closing: closing first would throw the typed
            // values away and leave the user to retype all of them.
            if (!MoneyInput.TryRead(txtAmount, "an amount", out decimal amount, out string error))
            {
                MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.FocusInput();
                return;
            }

            _amount = amount;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
