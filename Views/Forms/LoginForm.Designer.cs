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
            lbBrand = new Label();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            fieldUsername = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            txtUsername = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            fieldPassword = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            txtPassword = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            btnLogin = new PersonalExpenseTracker.Views.UI.Controls.AppButton();
            btnExit = new PersonalExpenseTracker.Views.UI.Controls.AppButton();
            lbFooter = new Label();
            root.SuspendLayout();
            brandRow.SuspendLayout();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Color.FromArgb(255, 255, 255);
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
            root.RowCount = 9;
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            root.RowStyles.Add(new RowStyle());
            root.RowStyles.Add(new RowStyle());
            root.RowStyles.Add(new RowStyle());
            root.RowStyles.Add(new RowStyle());
            root.RowStyles.Add(new RowStyle());
            root.RowStyles.Add(new RowStyle());
            root.RowStyles.Add(new RowStyle());
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            root.Size = new Size(332, 560);
            root.TabIndex = 0;
            // 
            // brandRow
            // 
            brandRow.Anchor = AnchorStyles.None;
            brandRow.AutoSize = true;
            brandRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            brandRow.BackColor = Color.FromArgb(255, 255, 255);
            brandRow.Controls.Add(lbBrand);
            brandRow.Location = new Point(106, 67);
            brandRow.Margin = new Padding(0, 0, 0, 20);
            brandRow.Name = "brandRow";
            brandRow.Size = new Size(119, 46);
            brandRow.TabIndex = 0;
            brandRow.WrapContents = false;
            // 
            // lbBrand
            // 
            lbBrand.AutoSize = true;
            lbBrand.BackColor = Color.FromArgb(255, 255, 255);
            lbBrand.Font = new Font("Lexend Black", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbBrand.ForeColor = Color.FromArgb(24, 24, 27);
            lbBrand.Location = new Point(0, 0);
            lbBrand.Margin = new Padding(0);
            lbBrand.Name = "lbBrand";
            lbBrand.Size = new Size(119, 46);
            lbBrand.TabIndex = 1;
            lbBrand.Text = "Finora";
            lbBrand.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // heading1
            // 
            heading1.AutoSize = true;
            heading1.BackColor = Color.FromArgb(255, 255, 255);
            heading1.description = "Sign in to continue to your personal finance tracker.";
            heading1.Dock = DockStyle.Top;
            heading1.Location = new Point(0, 133);
            heading1.Margin = new Padding(0, 0, 0, 20);
            heading1.Name = "heading1";
            heading1.Size = new Size(332, 54);
            heading1.TabIndex = 1;
            heading1.Title = "Welcome back";
            // 
            // fieldUsername
            // 
            fieldUsername.AutoSize = true;
            fieldUsername.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldUsername.BackColor = Color.Transparent;
            fieldUsername.Caption = "Username";
            fieldUsername.Dock = DockStyle.Top;
            fieldUsername.Location = new Point(0, 207);
            fieldUsername.Margin = new Padding(0, 0, 0, 14);
            fieldUsername.Name = "fieldUsername";
            fieldUsername.Size = new Size(332, 62);
            fieldUsername.TabIndex = 2;
            fieldUsername.Input = txtUsername;
            // 
            // txtUsername
            // 
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Lexend", 12F);
            txtUsername.LeadingIcon = "user";
            txtUsername.Location = new Point(0, 22);
            txtUsername.Margin = new Padding(0);
            txtUsername.MaxLength = 32767;
            txtUsername.Name = "txtUsername";
            txtUsername.Placeholder = "Enter your username";
            txtUsername.Size = new Size(332, 40);
            txtUsername.TabIndex = 0;
            txtUsername.TabStop = false;
            // 
            // fieldPassword
            // 
            fieldPassword.AutoSize = true;
            fieldPassword.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldPassword.BackColor = Color.Transparent;
            fieldPassword.Caption = "Password";
            fieldPassword.Dock = DockStyle.Top;
            fieldPassword.Location = new Point(0, 283);
            fieldPassword.Margin = new Padding(0, 0, 0, 20);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.Size = new Size(332, 62);
            fieldPassword.TabIndex = 3;
            fieldPassword.Input = txtPassword;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Lexend", 12F);
            txtPassword.IsPassword = true;
            txtPassword.LeadingIcon = "lock";
            txtPassword.Location = new Point(0, 22);
            txtPassword.Margin = new Padding(0);
            txtPassword.MaxLength = 32767;
            txtPassword.Name = "txtPassword";
            txtPassword.Placeholder = "Enter your password";
            txtPassword.Size = new Size(332, 40);
            txtPassword.TabIndex = 0;
            txtPassword.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.AutoWidth = false;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Caption = "Sign in";
            btnLogin.Dock = DockStyle.Top;
            btnLogin.Font = new Font("Lexend SemiBold", 10.5F);
            btnLogin.ForeColor = Color.FromArgb(24, 24, 27);
            btnLogin.Location = new Point(0, 365);
            btnLogin.Margin = new Padding(0, 0, 0, 10);
            btnLogin.MinimumSize = new Size(80, 0);
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
            btnExit.Font = new Font("Lexend SemiBold", 10.5F);
            btnExit.ForeColor = Color.FromArgb(82, 82, 91);
            btnExit.Location = new Point(0, 417);
            btnExit.Margin = new Padding(0, 0, 0, 18);
            btnExit.MinimumSize = new Size(59, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(332, 38);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.Variant = UI.Controls.AppButtonVariant.Ghost;
            btnExit.Click += btnExit_Click;
            // 
            // lbFooter
            // 
            lbFooter.AutoSize = true;
            lbFooter.Dock = DockStyle.Top;
            lbFooter.Font = new Font("Lexend", 9F);
            lbFooter.ForeColor = Color.FromArgb(161, 161, 170);
            lbFooter.Location = new Point(0, 473);
            lbFooter.Margin = new Padding(0);
            lbFooter.Name = "lbFooter";
            lbFooter.Size = new Size(332, 19);
            lbFooter.TabIndex = 6;
            lbFooter.Text = "© 2026 Finora";
            lbFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 255);
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
