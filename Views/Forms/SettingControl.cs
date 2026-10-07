using System;
using System.Windows.Forms;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Persistence;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// Settings page. The left side is who is signed in; the right side is the
    /// password change form itself - there is no dialog to open - and below
    /// them the preference Finora keeps for this device. The preference is
    /// handed straight to <see cref="AppPreferencesStore"/>, which puts the
    /// chosen culture on the thread every page already formats money and dates
    /// through, so a choice made here reaches the whole app at once.
    /// </summary>
    public partial class SettingControl : UserControl
    {
        /// <summary>
        /// What the "Currency &amp; format" row offers. The culture decides the
        /// currency symbol as well as the date format; null is the OS choice.
        /// </summary>
        private static readonly (string? Culture, string Label)[] Cultures =
        {
            (null, "System default"),
            ("en-US", "US Dollar ($)"),
            ("en-GB", "British Pound (\u00A3)"),
            ("de-DE", "Euro (\u20AC)"),
            ("hi-IN", "Indian Rupee (\u20B9)"),
            ("vi-VN", "Vietnamese Dong (\u20AB)"),
            ("km-KH", "Khmer Riel (\u17DB)")
        };

        private readonly CurrentUserSession _session;
        private readonly AuthenticationController _authenticationController;
        private readonly AppPreferencesStore _preferences;

        /// <summary>Stops loading the saved values from writing them straight back.</summary>
        private bool _loadingPreferences;

        /// <summary>
        /// Raised once the session has been cleared and the window is ready to
        /// close. MainForm owns the window, so it is the one that ends the run.
        /// </summary>
        public event EventHandler? LogoutRequested;

        public SettingControl(
            AuthenticationController authenticationController,
            CurrentUserSession session,
            AppPreferencesStore preferences)
        {
            _authenticationController = authenticationController;
            _session = session;

            // The same singleton Program loads at startup and the other pages
            // read, so a change made here is what they see - and because the
            // store applies its culture when it is first read, the saved format
            // is already in effect before this page is built.
            _preferences = preferences;

            InitializeComponent();

            foreach (var culture in Cultures)
                cbCulture.Items.Add(culture.Label);

            // A message about what was typed must not outlive the typing.
            txtCurrent.TextChanged += (_, _) => ClearStatus();
            txtNew.TextChanged += (_, _) => ClearStatus();
            txtConfirm.TextChanged += (_, _) => ClearStatus();

            LoadPreferences();
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
                lbMeta.Text = string.Empty;
                return;
            }

            avatar.Initials = _session.Username.Substring(0, 1).ToUpperInvariant();
            lbName.Text = _session.Username;
            lbMeta.Text = $"Account #{_session.UserId} - stored locally in finora.db";
        }

        //
        // Password - the three fields are on the page, so the whole flow is.
        //

        private void btnUpdatePassword_Click(object? sender, EventArgs e)
        {
            ClearStatus();

            if (_session == null || !_session.IsSignedIn ||
                string.IsNullOrWhiteSpace(_session.Username))
            {
                ShowStatus("You are not signed in.", success: false);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCurrent.Text) ||
                string.IsNullOrWhiteSpace(txtNew.Text) ||
                string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                ShowStatus("Fill in all three password fields.", success: false);
                return;
            }

            if (txtNew.Text.Length < 6)
            {
                ShowStatus("The new password needs at least 6 characters.", success: false);
                txtNew.FocusInput();
                return;
            }

            if (!string.Equals(txtNew.Text, txtConfirm.Text, StringComparison.Ordinal))
            {
                ShowStatus("The new passwords do not match.", success: false);
                txtConfirm.Text = string.Empty;
                txtConfirm.FocusInput();
                return;
            }

            try
            {
                _authenticationController.ChangePassword(
                    _session.Username, txtCurrent.Text, txtNew.Text);
            }
            catch (Exception ex)
            {
                ShowStatus(ex.Message, success: false);
                txtCurrent.FocusInput();
                return;
            }

            txtCurrent.Text = string.Empty;
            txtNew.Text = string.Empty;
            txtConfirm.Text = string.Empty;
            ShowStatus("Password updated. Use it next time you sign in.", success: true);
        }

        /// <summary>
        /// Enter submits from any of the three fields - there is no button
        /// between the typing and the result, so the key has to do the same
        /// job the button does.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter &&
                (txtCurrent.ContainsFocus || txtNew.ContainsFocus || txtConfirm.ContainsFocus))
            {
                btnUpdatePassword_Click(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ShowStatus(string message, bool success)
        {
            lbPasswordStatus.Text = message;
            lbPasswordStatus.ForeColor = success ? Colors.Success : Colors.Danger;
            lbPasswordStatus.Visible = true;
        }

        private void ClearStatus()
        {
            lbPasswordStatus.Text = string.Empty;
            lbPasswordStatus.Visible = false;
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

        //
        // Preferences
        //

        private void LoadPreferences()
        {
            _loadingPreferences = true;
            try
            {
                int index = 0;
                string? current = _preferences.Current.CultureName;

                if (!string.IsNullOrEmpty(current))
                {
                    for (int i = 0; i < Cultures.Length; i++)
                    {
                        if (string.Equals(Cultures[i].Culture, current,
                                          StringComparison.OrdinalIgnoreCase))
                        {
                            index = i;
                            break;
                        }
                    }
                }

                cbCulture.SelectedIndex = index;
            }
            finally
            {
                _loadingPreferences = false;
            }
        }

        private void cbCulture_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_loadingPreferences)
                return;

            int index = cbCulture.SelectedIndex;
            string? culture = index >= 0 && index < Cultures.Length
                ? Cultures[index].Culture
                : null;

            _preferences.SetCulture(culture);
        }
    }
}
