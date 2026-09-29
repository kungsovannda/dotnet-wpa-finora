using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            root = new TableLayoutPanel();
            brandRow = new FlowLayoutPanel();
            brand = new Views.UI.Controls.AvatarView();
            lbBrand = new Label();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            fieldUsername = new Views.UI.Controls.FormField();
            txtUsername = new Views.UI.Controls.AppTextField();
            fieldPassword = new Views.UI.Controls.FormField();
            txtPassword = new Views.UI.Controls.AppTextField();
            btnLogin = new Views.UI.Controls.AppButton();
            btnExit = new Views.UI.Controls.AppButton();
            lbFooter = new Label();
            root.SuspendLayout();
            brandRow.SuspendLayout();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Colors.Surface;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(brandRow, 0, 1);
            root.Controls.Add(heading1, 0, 2);
            root.Controls.Add(fieldUsername, 0, 3);
            root.Controls.Add(fieldPassword, 0, 4);
            root.Controls.Add(btnLogin, 0, 5);
            root.Controls.Add(btnExit, 0, 6);
            root.Controls.Add(lbFooter, 0, 7);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(44, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.Padding = new Padding(0);
            root.RowCount = 9;
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            root.Size = new Size(332, 560);
            root.TabIndex = 0;
            // 
            // brandRow
            // 
            brandRow.Anchor = AnchorStyles.None;
            brandRow.AutoSize = true;
            brandRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            brandRow.BackColor = Colors.Surface;
            brandRow.Controls.Add(brand);
            brandRow.Controls.Add(lbBrand);
            brandRow.Location = new Point(0, 0);
            brandRow.Margin = new Padding(0, 0, 0, 20);
            brandRow.Name = "brandRow";
            brandRow.WrapContents = false;
            brandRow.Size = new Size(120, 32);
            brandRow.TabIndex = 0;
            // 
            // brand
            // 
            brand.Fill = Colors.PrimaryOrange;
            brand.Fill2 = Colors.PrimaryHover;
            brand.Foreground = Colors.OnPrimary;
            brand.Initials = "F";
            brand.Location = new Point(0, 0);
            brand.Margin = new Padding(0, 0, 10, 0);
            brand.Name = "brand";
            brand.Size = new Size(32, 32);
            brand.TabIndex = 0;
            // 
            // lbBrand
            // 
            lbBrand.AutoSize = true;
            lbBrand.BackColor = Colors.Surface;
            lbBrand.Font = Typography.PageTitle;
            lbBrand.ForeColor = Colors.Foreground;
            lbBrand.Location = new Point(42, 0);
            lbBrand.Margin = new Padding(0);
            lbBrand.Name = "lbBrand";
            lbBrand.Size = new Size(78, 30);
            lbBrand.TabIndex = 1;
            lbBrand.Text = "Finora";
            lbBrand.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // heading1
            // 
            heading1.BackColor = Colors.Surface;
            heading1.description = "Sign in to continue to your personal finance tracker.";
            heading1.Dock = DockStyle.Top;
            heading1.Location = new Point(0, 52);
            heading1.Margin = new Padding(0, 0, 0, 20);
            heading1.Name = "heading1";
            heading1.Size = new Size(332, 52);
            heading1.TabIndex = 1;
            heading1.Title = "Welcome back";
            // 
            // fieldUsername
            // 
            fieldUsername.Caption = "Username";
            fieldUsername.Dock = DockStyle.Top;
            fieldUsername.Location = new Point(0, 124);
            fieldUsername.Margin = new Padding(0, 0, 0, 14);
            fieldUsername.Name = "fieldUsername";
            fieldUsername.Size = new Size(332, 60);
            fieldUsername.TabIndex = 2;
            fieldUsername.Input = txtUsername;
            // 
            // txtUsername
            // 
            txtUsername.LeadingIcon = Views.UI.Icons.User;
            txtUsername.Location = new Point(0, 0);
            txtUsername.Margin = new Padding(0);
            txtUsername.Name = "txtUsername";
            txtUsername.Placeholder = "Enter your username";
            txtUsername.Size = new Size(332, 40);
            txtUsername.TabIndex = 0;
            // 
            // fieldPassword
            // 
            fieldPassword.Caption = "Password";
            fieldPassword.Dock = DockStyle.Top;
            fieldPassword.Location = new Point(0, 198);
            fieldPassword.Margin = new Padding(0, 0, 0, 20);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.Size = new Size(332, 60);
            fieldPassword.TabIndex = 3;
            fieldPassword.Input = txtPassword;
            // 
            // txtPassword
            // 
            txtPassword.IsPassword = true;
            txtPassword.LeadingIcon = Views.UI.Icons.Lock;
            txtPassword.Location = new Point(0, 0);
            txtPassword.Margin = new Padding(0);
            txtPassword.Name = "txtPassword";
            txtPassword.Placeholder = "Enter your password";
            txtPassword.Size = new Size(332, 40);
            txtPassword.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.AutoWidth = false;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Caption = "Sign in";
            btnLogin.Dock = DockStyle.Top;
            btnLogin.Location = new Point(0, 278);
            btnLogin.Margin = new Padding(0, 0, 0, 10);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(332, 42);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Sign in";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.AutoWidth = false;
            btnExit.BackColor = Color.Transparent;
            btnExit.Caption = "Exit";
            btnExit.Dock = DockStyle.Top;
            btnExit.Location = new Point(0, 330);
            btnExit.Margin = new Padding(0, 0, 0, 18);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(332, 38);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.Variant = Views.UI.Controls.AppButtonVariant.Ghost;
            btnExit.Click += btnExit_Click;
            // 
            // lbFooter
            // 
            lbFooter.AutoSize = true;
            lbFooter.Dock = DockStyle.Top;
            lbFooter.Font = Typography.Caption;
            lbFooter.ForeColor = Colors.FaintText;
            lbFooter.Location = new Point(0, 386);
            lbFooter.Margin = new Padding(0);
            lbFooter.Name = "lbFooter";
            lbFooter.Size = new Size(332, 18);
            lbFooter.TabIndex = 6;
            lbFooter.Text = "© 2026 Finora";
            lbFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            ClientSize = new Size(420, 560);
            Controls.Add(root);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Padding = new Padding(44, 0, 44, 0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Finora";
            root.ResumeLayout(false);
            root.PerformLayout();
            brandRow.ResumeLayout(false);
            brandRow.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private FlowLayoutPanel brandRow;
        private Views.UI.Controls.AvatarView brand;
        private Label lbBrand;
        private Controls.Heading heading1;
        private Views.UI.Controls.FormField fieldUsername;
        private Views.UI.Controls.AppTextField txtUsername;
        private Views.UI.Controls.FormField fieldPassword;
        private Views.UI.Controls.AppTextField txtPassword;
        private Views.UI.Controls.AppButton btnLogin;
        private Views.UI.Controls.AppButton btnExit;
        private Label lbFooter;
    }
}
