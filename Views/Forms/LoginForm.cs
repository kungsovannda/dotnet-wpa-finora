using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Views.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationController _authenticationController;
        private readonly CurrentUserSession _session;
        private bool _showingRegister;

        public LoginForm(AuthenticationController authenticationController, CurrentUserSession session)
        {
            _authenticationController = authenticationController;
            _session = session;
            InitializeComponent();
            Typography.Apply(this);
            txtUsername.FocusInput();
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            HideError();

            try
            {
                if (_showingRegister)
                {
                    Register();
                }
                else
                {
                    Login();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                txtPassword.Text = string.Empty;
                txtPassword.FocusInput();
            }
        }

        private void Login()
        {
            var user = _authenticationController.Login(txtUsername.Text, txtPassword.Text);
            _session.SignIn(user.Id, user.Username);
            lbFooter.Text = $"Signed in as {user.Username}";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Register()
        {
            // Minimal validation before hitting the controller.
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 3)
            {
                ShowError("Username must be at least 3 characters long.");
                txtUsername.FocusInput();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                ShowError("Password must be at least 6 characters long.");
                txtPassword.FocusInput();
                return;
            }

            var user = _authenticationController.Register(
                txtUsername.Text,
                txtPassword.Text,
                string.Empty, // firstName - optional for now
                string.Empty, // lastName - optional for now
                string.Empty); // email - optional for now

            _session.SignIn(user.Id, user.Username);
            lbFooter.Text = $"Signed in as {user.Username}";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowError(string message)
        {
            lbError.Text = message;
            lbError.Visible = true;
        }

        private void HideError()
        {
            lbError.Text = string.Empty;
            lbError.Visible = false;
        }

        private void btnSwitch_Click(object? sender, EventArgs e)
        {
            HideError();
            _showingRegister = !_showingRegister;

            if (_showingRegister)
            {
                heading1.Title = "Create account";
                heading1.description = "Choose a username and password to get started.";
                btnLogin.Caption = "Create account";
                btnSwitch.Caption = "Already have an account? Sign in";
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            else
            {
                heading1.Title = "Welcome back";
                heading1.description = "Sign in to continue to your personal finance tracker.";
                btnLogin.Caption = "Sign in";
                btnSwitch.Caption = "Create an account";
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }

            txtUsername.FocusInput();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            using var path = Theme.RoundedPath(
                new RectangleF(0, 0, Width, Height),
                Theme.Scaled(Theme.RadiusXl, Theme.ScaleOf(this)));
            var region = new Region(path);
            var previous = Region;
            Region = region;
            previous?.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            Theme.SetupQuality(g);
            using var pen = new Pen(Colors.Border, 1f);
            using var path = Theme.RoundedPath(
                new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f),
                Theme.Scaled(Theme.RadiusXl, Theme.ScaleOf(this)));
            g.DrawPath(pen, path);
        }
    }
}
