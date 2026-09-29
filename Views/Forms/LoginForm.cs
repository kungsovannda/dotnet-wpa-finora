using PersonalExpenseTracker.Views.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Typography.Apply(this);
            txtUsername.FocusInput();
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
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
