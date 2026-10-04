using System;
using System.Windows.Forms;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// Collects the three passwords a change needs. The dialog only matches
    /// what was typed against what was typed - every rule about the password
    /// itself belongs to the authentication service.
    /// </summary>
    public partial class ChangePasswordDialog : Form
    {
        private readonly AuthenticationController _authenticationController;
        private readonly CurrentUserSession _session;

        public ChangePasswordDialog(AuthenticationController authenticationController, CurrentUserSession session)
        {
            _authenticationController = authenticationController;
            _session = session;
            InitializeComponent();

            heading1.description = "Choose a password you have not used before.";
        }

        public string CurrentPassword => txtCurrent.Text;

        public string NewPassword => txtNew.Text;

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_session.Username))
            {
                ShowError("You are not signed in.");
                return;
            }

            if (!string.Equals(txtNew.Text, txtConfirm.Text, StringComparison.Ordinal))
            {
                ShowError("The new passwords do not match.");
                txtConfirm.Text = string.Empty;
                txtConfirm.FocusInput();
                return;
            }

            try
            {
                _authenticationController.ChangePassword(_session.Username, txtCurrent.Text, txtNew.Text);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                txtCurrent.FocusInput();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
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
