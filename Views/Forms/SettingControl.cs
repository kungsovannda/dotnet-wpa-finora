using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// Account page. It reads the signed-in session and offers the two account
    /// actions; it never reaches past its controller to change anything itself.
    /// </summary>
    public partial class SettingControl : UserControl
    {
        private readonly IServiceProvider serviceProvider;
        private readonly CurrentUserSession _session;

        /// <summary>
        /// Raised once the session has been cleared and the window is ready to
        /// close. MainForm owns the window, so it is the one that ends the run.
        /// </summary>
        public event EventHandler? LogoutRequested;

        public SettingControl(IServiceProvider serviceProvider, CurrentUserSession session)
        {
            this.serviceProvider = serviceProvider;
            _session = session;
            InitializeComponent();
        }

        private void SettingControl_Load(object sender, EventArgs e)
        {
            BindSession();
        }

        public void RefreshData()
        {
            if (IsDisposed)
                return;

            BindSession();
        }

        private void BindSession()
        {
            if (_session == null || !_session.IsSignedIn)
            {
                avatar.Initials = "U";
                lbName.Text = "Not signed in";
                lbUsername.Text = string.Empty;
                return;
            }

            avatar.Initials = _session.Username.Substring(0, 1).ToUpperInvariant();
            lbName.Text = _session.Username;
            lbUsername.Text = _session.IsSignedIn
                ? $"Account #{_session.UserId} - data is stored locally in finora.db"
                : string.Empty;
        }

        private void btnChangePassword_Click(object? sender, EventArgs e)
        {
            using var dialog = serviceProvider.GetRequiredService<ChangePasswordDialog>();

            if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                return;

            MessageBox.Show(
                FindForm(),
                "Your password has been updated. Use it next time you sign in.",
                "Password changed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            var answer = MessageBox.Show(
                FindForm(),
                "Log out of Finora? Anything already saved stays saved.",
                "Log out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            _session.SignOut();
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
