using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class SettingControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            root = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            profileCard = new Views.UI.Controls.SectionCard();
            profile = new TableLayoutPanel();
            avatar = new Views.UI.Controls.AvatarView();
            profileNames = new TableLayoutPanel();
            lbName = new Label();
            lbUsername = new Label();
            accountCard = new Views.UI.Controls.SectionCard();
            account = new TableLayoutPanel();
            lbAccountTitle = new Label();
            tiles = new TableLayoutPanel();
            passwordTile = new TableLayoutPanel();
            lbPasswordTitle = new Label();
            lbPasswordCaption = new Label();
            btnChangePassword = new Views.UI.Controls.AppButton();
            sessionTile = new TableLayoutPanel();
            lbSessionTitle = new Label();
            lbSessionCaption = new Label();
            btnLogout = new Views.UI.Controls.AppButton();
            root.SuspendLayout();
            profileCard.SuspendLayout();
            profile.SuspendLayout();
            profileNames.SuspendLayout();
            accountCard.SuspendLayout();
            account.SuspendLayout();
            tiles.SuspendLayout();
            passwordTile.SuspendLayout();
            sessionTile.SuspendLayout();
            SuspendLayout();
            //
            // root
            //
            root.BackColor = Colors.Background;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(heading1, 0, 0);
            root.Controls.Add(profileCard, 0, 1);
            root.Controls.Add(accountCard, 0, 2);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 3;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 116F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(900, 620);
            root.TabIndex = 0;
            //
            // heading1
            //
            heading1.BackColor = Colors.Background;
            heading1.description = "Your account and how you sign in.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(900, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Settings";
            //
            // profileCard
            //
            profileCard.Border = Colors.Border;
            profileCard.Controls.Add(profile);
            profileCard.Dock = DockStyle.Fill;
            profileCard.Location = new Point(0, 72);
            profileCard.Margin = new Padding(0, 4, 0, 0);
            profileCard.Name = "profileCard";
            profileCard.Padding = new Padding(24, 18, 24, 18);
            profileCard.Radius = Theme.RadiusLg;
            profileCard.ShowShadow = true;
            profileCard.Size = new Size(900, 112);
            profileCard.Surface = Colors.Surface;
            profileCard.TabIndex = 1;
            //
            // profile
            //
            profile.BackColor = Colors.Surface;
            profile.ColumnCount = 2;
            profile.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            profile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            profile.Controls.Add(avatar, 0, 0);
            profile.Controls.Add(profileNames, 1, 0);
            profile.Dock = DockStyle.Fill;
            profile.Location = new Point(24, 18);
            profile.Margin = new Padding(0);
            profile.Name = "profile";
            profile.RowCount = 1;
            profile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            profile.Size = new Size(852, 76);
            profile.TabIndex = 0;
            //
            // avatar
            //
            avatar.Anchor = AnchorStyles.Left;
            avatar.BackColor = Colors.Surface;
            avatar.Diameter = 64;
            avatar.Initials = "U";
            avatar.Location = new Point(0, 6);
            avatar.Margin = new Padding(0, 0, 20, 0);
            avatar.Name = "avatar";
            avatar.Size = new Size(64, 64);
            avatar.TabIndex = 0;
            //
            // profileNames
            //
            profileNames.BackColor = Colors.Surface;
            profileNames.ColumnCount = 1;
            profileNames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            profileNames.Controls.Add(lbName, 0, 0);
            profileNames.Controls.Add(lbUsername, 0, 1);
            profileNames.Dock = DockStyle.Fill;
            profileNames.Location = new Point(84, 0);
            profileNames.Margin = new Padding(0);
            profileNames.Name = "profileNames";
            profileNames.RowCount = 2;
            profileNames.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            profileNames.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            profileNames.Size = new Size(768, 76);
            profileNames.TabIndex = 1;
            //
            // lbName
            //
            lbName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbName.AutoSize = true;
            lbName.BackColor = Colors.Surface;
            lbName.Font = new Font("Lexend", 16F, FontStyle.Bold);
            lbName.ForeColor = Color.FromArgb(24, 24, 27);
            lbName.Location = new Point(0, 12);
            lbName.Margin = new Padding(0);
            lbName.Name = "lbName";
            lbName.Size = new Size(768, 29);
            lbName.TabIndex = 0;
            lbName.Text = "Signed in";
            lbName.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lbUsername
            //
            lbUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbUsername.AutoSize = true;
            lbUsername.BackColor = Colors.Surface;
            lbUsername.Font = new Font("Lexend", 9.5F);
            lbUsername.ForeColor = Color.FromArgb(113, 113, 122);
            lbUsername.Location = new Point(0, 44);
            lbUsername.Margin = new Padding(0);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(768, 21);
            lbUsername.TabIndex = 1;
            lbUsername.TextAlign = ContentAlignment.MiddleLeft;
            //
            // accountCard
            //
            accountCard.Border = Colors.Border;
            accountCard.Controls.Add(account);
            accountCard.Dock = DockStyle.Fill;
            accountCard.Location = new Point(0, 192);
            accountCard.Margin = new Padding(0, 16, 0, 0);
            accountCard.Name = "accountCard";
            accountCard.Padding = new Padding(24, 18, 24, 18);
            accountCard.Radius = Theme.RadiusLg;
            accountCard.ShowShadow = true;
            accountCard.Size = new Size(900, 424);
            accountCard.Surface = Colors.Surface;
            accountCard.TabIndex = 2;
            //
            // account
            //
            account.BackColor = Colors.Surface;
            account.ColumnCount = 1;
            account.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            account.Controls.Add(lbAccountTitle, 0, 0);
            account.Controls.Add(tiles, 0, 1);
            account.Dock = DockStyle.Fill;
            account.Location = new Point(24, 18);
            account.Margin = new Padding(0);
            account.Name = "account";
            account.RowCount = 2;
            account.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            account.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            account.Size = new Size(852, 388);
            account.TabIndex = 0;
            //
            // lbAccountTitle
            //
            lbAccountTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbAccountTitle.AutoSize = true;
            lbAccountTitle.BackColor = Colors.Surface;
            lbAccountTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbAccountTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbAccountTitle.Location = new Point(0, 0);
            lbAccountTitle.Margin = new Padding(0, 0, 0, 16);
            lbAccountTitle.Name = "lbAccountTitle";
            lbAccountTitle.Size = new Size(852, 34);
            lbAccountTitle.TabIndex = 0;
            lbAccountTitle.Text = "Account";
            lbAccountTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // tiles
            //
            tiles.BackColor = Colors.Surface;
            tiles.ColumnCount = 2;
            tiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tiles.Controls.Add(passwordTile, 0, 0);
            tiles.Controls.Add(sessionTile, 1, 0);
            tiles.Dock = DockStyle.Fill;
            tiles.Location = new Point(0, 34);
            tiles.Margin = new Padding(0);
            tiles.Name = "tiles";
            tiles.RowCount = 1;
            tiles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tiles.Size = new Size(852, 354);
            tiles.TabIndex = 1;
            //
            // passwordTile
            //
            passwordTile.BackColor = Color.FromArgb(250, 250, 249);
            passwordTile.ColumnCount = 1;
            passwordTile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            passwordTile.Controls.Add(lbPasswordTitle, 0, 0);
            passwordTile.Controls.Add(lbPasswordCaption, 0, 1);
            passwordTile.Controls.Add(btnChangePassword, 0, 2);
            passwordTile.Location = new Point(0, 0);
            passwordTile.Margin = new Padding(0, 0, 16, 0);
            passwordTile.Name = "passwordTile";
            passwordTile.Padding = new Padding(20, 20, 20, 20);
            passwordTile.RowCount = 3;
            passwordTile.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            passwordTile.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            passwordTile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            passwordTile.Size = new Size(418, 354);
            passwordTile.TabIndex = 0;
            //
            // lbPasswordTitle
            //
            lbPasswordTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbPasswordTitle.AutoSize = true;
            lbPasswordTitle.BackColor = Color.FromArgb(250, 250, 249);
            lbPasswordTitle.Font = new Font("Lexend SemiBold", 12F);
            lbPasswordTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbPasswordTitle.Location = new Point(20, 20);
            lbPasswordTitle.Margin = new Padding(0, 0, 0, 8);
            lbPasswordTitle.Name = "lbPasswordTitle";
            lbPasswordTitle.Size = new Size(378, 23);
            lbPasswordTitle.TabIndex = 0;
            lbPasswordTitle.Text = "Password";
            lbPasswordTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lbPasswordCaption
            //
            lbPasswordCaption.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbPasswordCaption.AutoSize = true;
            lbPasswordCaption.BackColor = Color.FromArgb(250, 250, 249);
            lbPasswordCaption.Font = new Font("Lexend", 9.5F);
            lbPasswordCaption.ForeColor = Color.FromArgb(113, 113, 122);
            lbPasswordCaption.Location = new Point(20, 59);
            lbPasswordCaption.Margin = new Padding(0, 0, 0, 20);
            lbPasswordCaption.Name = "lbPasswordCaption";
            lbPasswordCaption.Size = new Size(378, 20);
            lbPasswordCaption.TabIndex = 1;
            lbPasswordCaption.Text = "Replace the password you sign in with.";
            lbPasswordCaption.TextAlign = ContentAlignment.MiddleLeft;
            //
            // btnChangePassword
            //
            btnChangePassword.Anchor = AnchorStyles.Left;
            btnChangePassword.AutoWidth = false;
            btnChangePassword.BackColor = Color.Transparent;
            btnChangePassword.Caption = "Change Password";
            btnChangePassword.Font = new Font("Lexend SemiBold", 10.5F);
            btnChangePassword.ForeColor = Color.FromArgb(24, 24, 27);
            btnChangePassword.Icon = "lock";
            btnChangePassword.Location = new Point(20, 99);
            btnChangePassword.Margin = new Padding(0);
            btnChangePassword.MinimumSize = new Size(170, 0);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(170, 38);
            btnChangePassword.TabIndex = 2;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.Click += btnChangePassword_Click;
            //
            // sessionTile
            //
            sessionTile.BackColor = Color.FromArgb(250, 250, 249);
            sessionTile.ColumnCount = 1;
            sessionTile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sessionTile.Controls.Add(lbSessionTitle, 0, 0);
            sessionTile.Controls.Add(lbSessionCaption, 0, 1);
            sessionTile.Controls.Add(btnLogout, 0, 2);
            sessionTile.Location = new Point(434, 0);
            sessionTile.Margin = new Padding(0);
            sessionTile.Name = "sessionTile";
            sessionTile.Padding = new Padding(20, 20, 20, 20);
            sessionTile.RowCount = 3;
            sessionTile.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            sessionTile.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            sessionTile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sessionTile.Size = new Size(418, 354);
            sessionTile.TabIndex = 1;
            //
            // lbSessionTitle
            //
            lbSessionTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbSessionTitle.AutoSize = true;
            lbSessionTitle.BackColor = Color.FromArgb(250, 250, 249);
            lbSessionTitle.Font = new Font("Lexend SemiBold", 12F);
            lbSessionTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbSessionTitle.Location = new Point(20, 20);
            lbSessionTitle.Margin = new Padding(0, 0, 0, 8);
            lbSessionTitle.Name = "lbSessionTitle";
            lbSessionTitle.Size = new Size(378, 23);
            lbSessionTitle.TabIndex = 0;
            lbSessionTitle.Text = "Session";
            lbSessionTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lbSessionCaption
            //
            lbSessionCaption.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbSessionCaption.AutoSize = true;
            lbSessionCaption.BackColor = Color.FromArgb(250, 250, 249);
            lbSessionCaption.Font = new Font("Lexend", 9.5F);
            lbSessionCaption.ForeColor = Color.FromArgb(113, 113, 122);
            lbSessionCaption.Location = new Point(20, 59);
            lbSessionCaption.Margin = new Padding(0, 0, 0, 20);
            lbSessionCaption.Name = "lbSessionCaption";
            lbSessionCaption.Size = new Size(378, 20);
            lbSessionCaption.TabIndex = 1;
            lbSessionCaption.Text = "End this session and return to the sign-in screen.";
            lbSessionCaption.TextAlign = ContentAlignment.MiddleLeft;
            //
            // btnLogout
            //
            btnLogout.Anchor = AnchorStyles.Left;
            btnLogout.AutoWidth = false;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.Caption = "Log Out";
            btnLogout.Font = new Font("Lexend SemiBold", 10.5F);
            btnLogout.ForeColor = Color.FromArgb(24, 24, 27);
            btnLogout.Icon = "user";
            btnLogout.Location = new Point(20, 99);
            btnLogout.Margin = new Padding(0);
            btnLogout.MinimumSize = new Size(130, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 38);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log Out";
            btnLogout.Variant = Views.UI.Controls.AppButtonVariant.Secondary;
            btnLogout.Click += btnLogout_Click;
            //
            // SettingControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Background;
            Controls.Add(root);
            Name = "SettingControl";
            Size = new Size(900, 620);
            Load += SettingControl_Load;
            root.ResumeLayout(false);
            profileCard.ResumeLayout(false);
            profile.ResumeLayout(false);
            profile.PerformLayout();
            profileNames.ResumeLayout(false);
            profileNames.PerformLayout();
            accountCard.ResumeLayout(false);
            account.ResumeLayout(false);
            account.PerformLayout();
            tiles.ResumeLayout(false);
            passwordTile.ResumeLayout(false);
            passwordTile.PerformLayout();
            sessionTile.ResumeLayout(false);
            sessionTile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private Views.UI.Controls.SectionCard profileCard;
        private TableLayoutPanel profile;
        private Views.UI.Controls.AvatarView avatar;
        private TableLayoutPanel profileNames;
        private Label lbName;
        private Label lbUsername;
        private Views.UI.Controls.SectionCard accountCard;
        private TableLayoutPanel account;
        private Label lbAccountTitle;
        private TableLayoutPanel tiles;
        private TableLayoutPanel passwordTile;
        private Label lbPasswordTitle;
        private Label lbPasswordCaption;
        private Views.UI.Controls.AppButton btnChangePassword;
        private TableLayoutPanel sessionTile;
        private Label lbSessionTitle;
        private Label lbSessionCaption;
        private Views.UI.Controls.AppButton btnLogout;
    }
}
