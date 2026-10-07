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
            header = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            scrollHost = new Panel();
            content = new TableLayoutPanel();
            accountCard = new Views.UI.Controls.SectionCard();
            account = new TableLayoutPanel();
            lbAccountTitle = new Label();
            profile = new TableLayoutPanel();
            avatar = new Views.UI.Controls.AvatarView();
            names = new TableLayoutPanel();
            lbName = new Label();
            lbMeta = new Label();
            btnLogout = new Views.UI.Controls.AppButton();
            securityCard = new Views.UI.Controls.SectionCard();
            security = new TableLayoutPanel();
            lbSecurityTitle = new Label();
            passwordFields = new TableLayoutPanel();
            fieldCurrent = new Views.UI.Controls.FormField();
            txtCurrent = new Views.UI.Controls.AppTextField();
            fieldNew = new Views.UI.Controls.FormField();
            txtNew = new Views.UI.Controls.AppTextField();
            fieldConfirm = new Views.UI.Controls.FormField();
            txtConfirm = new Views.UI.Controls.AppTextField();
            securityFooter = new TableLayoutPanel();
            btnUpdatePassword = new Views.UI.Controls.AppButton();
            lbPasswordStatus = new Label();
            preferencesCard = new Views.UI.Controls.SectionCard();
            preferences = new TableLayoutPanel();
            lbPreferencesTitle = new Label();
            currencyHost = new TableLayoutPanel();
            lbCurrencyTitle = new Label();
            lbCurrencyCaption = new Label();
            cbCulture = new Views.UI.Controls.AppComboField();
            root.SuspendLayout();
            header.SuspendLayout();
            scrollHost.SuspendLayout();
            content.SuspendLayout();
            accountCard.SuspendLayout();
            account.SuspendLayout();
            profile.SuspendLayout();
            names.SuspendLayout();
            securityCard.SuspendLayout();
            security.SuspendLayout();
            passwordFields.SuspendLayout();
            securityFooter.SuspendLayout();
            preferencesCard.SuspendLayout();
            preferences.SuspendLayout();
            currencyHost.SuspendLayout();
            SuspendLayout();
            //
            // root
            //
            root.BackColor = Colors.Background;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(scrollHost, 0, 1);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 2;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(900, 620);
            root.TabIndex = 0;
            //
            // header
            //
            header.BackColor = Colors.Background;
            header.ColumnCount = 1;
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            header.Controls.Add(heading1, 0, 0);
            header.Dock = DockStyle.Fill;
            header.Location = new Point(0, 0);
            header.Margin = new Padding(0);
            header.Name = "header";
            header.RowCount = 1;
            header.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            header.Size = new Size(900, 68);
            header.TabIndex = 0;
            //
            // heading1
            //
            heading1.BackColor = Colors.Background;
            heading1.description = "Your account, security and how Finora behaves on this device.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(900, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Settings";
            //
            // scrollHost
            //
            scrollHost.AutoScroll = true;
            scrollHost.BackColor = Colors.Background;
            scrollHost.Controls.Add(content);
            scrollHost.Dock = DockStyle.Fill;
            scrollHost.Location = new Point(0, 68);
            scrollHost.Margin = new Padding(0);
            scrollHost.Name = "scrollHost";
            scrollHost.Padding = new Padding(0, 0, 0, 24);
            scrollHost.Size = new Size(900, 552);
            scrollHost.TabIndex = 1;
            //
            // content
            //
            content.BackColor = Colors.Background;
            content.ColumnCount = 2;
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            content.Controls.Add(accountCard, 0, 0);
            content.Controls.Add(securityCard, 1, 0);
            content.Controls.Add(preferencesCard, 0, 1);
            content.SetColumnSpan(preferencesCard, 2);
            content.Dock = DockStyle.Top;
            content.Location = new Point(0, 0);
            content.Margin = new Padding(0);
            content.Name = "content";
            content.RowCount = 3;
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 256F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.Size = new Size(900, 424);
            content.TabIndex = 0;
            //
            // accountCard
            //
            accountCard.Border = Colors.Border;
            accountCard.Controls.Add(account);
            accountCard.Dock = DockStyle.Fill;
            accountCard.Location = new Point(0, 4);
            accountCard.Margin = new Padding(0, 4, 16, 16);
            accountCard.Name = "accountCard";
            accountCard.Padding = new Padding(24, 18, 24, 18);
            accountCard.Radius = Theme.RadiusLg;
            accountCard.ShowShadow = true;
            accountCard.Size = new Size(344, 236);
            accountCard.Surface = Colors.Surface;
            accountCard.TabIndex = 0;
            //
            // account
            //
            account.BackColor = Colors.Surface;
            account.ColumnCount = 1;
            account.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            account.Controls.Add(lbAccountTitle, 0, 0);
            account.Controls.Add(profile, 0, 1);
            account.Controls.Add(btnLogout, 0, 2);
            account.Dock = DockStyle.Fill;
            account.Location = new Point(24, 18);
            account.Margin = new Padding(0);
            account.Name = "account";
            account.RowCount = 4;
            account.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            account.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            account.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            account.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            account.Size = new Size(296, 200);
            account.TabIndex = 0;
            //
            // lbAccountTitle
            //
            lbAccountTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbAccountTitle.AutoSize = true;
            lbAccountTitle.BackColor = Colors.Surface;
            lbAccountTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbAccountTitle.ForeColor = Colors.Foreground;
            lbAccountTitle.Location = new Point(0, 0);
            lbAccountTitle.Margin = new Padding(0, 0, 0, 12);
            lbAccountTitle.Name = "lbAccountTitle";
            lbAccountTitle.Size = new Size(296, 34);
            lbAccountTitle.TabIndex = 0;
            lbAccountTitle.Text = "Your account";
            lbAccountTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // profile
            //
            profile.BackColor = Colors.Surface;
            profile.ColumnCount = 2;
            profile.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            profile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            profile.Controls.Add(avatar, 0, 0);
            profile.Controls.Add(names, 1, 0);
            profile.Dock = DockStyle.Fill;
            profile.Location = new Point(0, 46);
            profile.Margin = new Padding(0);
            profile.Name = "profile";
            profile.RowCount = 1;
            profile.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            profile.Size = new Size(296, 84);
            profile.TabIndex = 1;
            //
            // avatar
            //
            avatar.Anchor = AnchorStyles.Left;
            avatar.BackColor = Colors.Surface;
            avatar.Diameter = 56;
            avatar.Initials = "U";
            avatar.Location = new Point(0, 14);
            avatar.Margin = new Padding(0, 0, 16, 0);
            avatar.Name = "avatar";
            avatar.Size = new Size(56, 56);
            avatar.TabIndex = 0;
            //
            // names
            //
            names.Anchor = AnchorStyles.Left;
            names.AutoSize = true;
            names.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            names.BackColor = Colors.Surface;
            names.ColumnCount = 1;
            names.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            names.Controls.Add(lbName, 0, 0);
            names.Controls.Add(lbMeta, 0, 1);
            names.Location = new Point(76, 20);
            names.Margin = new Padding(0);
            names.Name = "names";
            names.RowCount = 2;
            names.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            names.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            names.Size = new Size(140, 44);
            names.TabIndex = 1;
            //
            // lbName
            //
            lbName.AutoSize = true;
            lbName.BackColor = Colors.Surface;
            lbName.Font = new Font("Lexend", 13F, FontStyle.Bold);
            lbName.ForeColor = Colors.Foreground;
            lbName.Location = new Point(0, 0);
            lbName.Margin = new Padding(0);
            lbName.Name = "lbName";
            lbName.Size = new Size(74, 24);
            lbName.TabIndex = 0;
            lbName.Text = "Signed in";
            //
            // lbMeta
            //
            lbMeta.AutoSize = true;
            lbMeta.BackColor = Colors.Surface;
            lbMeta.Font = new Font("Lexend", 9.5F);
            lbMeta.ForeColor = Colors.MutedText;
            lbMeta.Location = new Point(0, 24);
            lbMeta.Margin = new Padding(0);
            lbMeta.Name = "lbMeta";
            lbMeta.Size = new Size(70, 20);
            lbMeta.TabIndex = 1;
            //
            // btnLogout
            //
            btnLogout.Anchor = AnchorStyles.Left;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.Caption = "Log Out";
            btnLogout.Font = new Font("Lexend SemiBold", 10.5F);
            btnLogout.ForeColor = Colors.Foreground;
            btnLogout.Icon = "user";
            btnLogout.Location = new Point(0, 4);
            btnLogout.Margin = new Padding(0, 4, 0, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(110, 38);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log Out";
            btnLogout.Variant = Views.UI.Controls.AppButtonVariant.Secondary;
            btnLogout.Click += btnLogout_Click;
            //
            // securityCard
            //
            securityCard.Border = Colors.Border;
            securityCard.Controls.Add(security);
            securityCard.Dock = DockStyle.Fill;
            securityCard.Location = new Point(360, 4);
            securityCard.Margin = new Padding(0, 4, 0, 16);
            securityCard.Name = "securityCard";
            securityCard.Padding = new Padding(24, 18, 24, 18);
            securityCard.Radius = Theme.RadiusLg;
            securityCard.ShowShadow = true;
            securityCard.Size = new Size(540, 236);
            securityCard.Surface = Colors.Surface;
            securityCard.TabIndex = 1;
            //
            // security
            //
            security.BackColor = Colors.Surface;
            security.ColumnCount = 1;
            security.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            security.Controls.Add(lbSecurityTitle, 0, 0);
            security.Controls.Add(passwordFields, 0, 1);
            security.Controls.Add(securityFooter, 0, 2);
            security.Dock = DockStyle.Fill;
            security.Location = new Point(24, 18);
            security.Margin = new Padding(0);
            security.Name = "security";
            security.RowCount = 3;
            security.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            security.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            security.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            security.Size = new Size(492, 200);
            security.TabIndex = 0;
            //
            // lbSecurityTitle
            //
            lbSecurityTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbSecurityTitle.AutoSize = true;
            lbSecurityTitle.BackColor = Colors.Surface;
            lbSecurityTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbSecurityTitle.ForeColor = Colors.Foreground;
            lbSecurityTitle.Location = new Point(0, 0);
            lbSecurityTitle.Margin = new Padding(0, 0, 0, 12);
            lbSecurityTitle.Name = "lbSecurityTitle";
            lbSecurityTitle.Size = new Size(492, 34);
            lbSecurityTitle.TabIndex = 0;
            lbSecurityTitle.Text = "Change password";
            lbSecurityTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // passwordFields
            //
            passwordFields.BackColor = Colors.Surface;
            passwordFields.ColumnCount = 3;
            passwordFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            passwordFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            passwordFields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            passwordFields.Controls.Add(fieldCurrent, 0, 0);
            passwordFields.Controls.Add(fieldNew, 1, 0);
            passwordFields.Controls.Add(fieldConfirm, 2, 0);
            passwordFields.Dock = DockStyle.Fill;
            passwordFields.Location = new Point(0, 46);
            passwordFields.Margin = new Padding(0, 0, 0, 14);
            passwordFields.Name = "passwordFields";
            passwordFields.RowCount = 1;
            passwordFields.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            passwordFields.Size = new Size(492, 82);
            passwordFields.TabIndex = 1;
            //
            // fieldCurrent
            //
            fieldCurrent.Caption = "Current Password";
            fieldCurrent.Dock = DockStyle.Top;
            fieldCurrent.Location = new Point(0, 0);
            fieldCurrent.Margin = new Padding(0, 0, 16, 0);
            fieldCurrent.Name = "fieldCurrent";
            fieldCurrent.Size = new Size(148, 62);
            fieldCurrent.TabIndex = 0;
            fieldCurrent.Input = txtCurrent;
            //
            // txtCurrent
            //
            txtCurrent.Dock = DockStyle.Fill;
            txtCurrent.IsPassword = true;
            txtCurrent.LeadingIcon = Views.UI.Icons.Lock;
            txtCurrent.Location = new Point(0, 0);
            txtCurrent.Margin = new Padding(0);
            txtCurrent.MaxLength = 64;
            txtCurrent.Name = "txtCurrent";
            txtCurrent.Placeholder = "Your current password";
            txtCurrent.Size = new Size(148, 40);
            txtCurrent.TabIndex = 0;
            //
            // fieldNew
            //
            fieldNew.Caption = "New Password";
            fieldNew.Dock = DockStyle.Top;
            fieldNew.Hint = "At least 6 characters.";
            fieldNew.Location = new Point(164, 0);
            fieldNew.Margin = new Padding(0, 0, 16, 0);
            fieldNew.Name = "fieldNew";
            fieldNew.Size = new Size(148, 82);
            fieldNew.TabIndex = 1;
            fieldNew.Input = txtNew;
            //
            // txtNew
            //
            txtNew.Dock = DockStyle.Fill;
            txtNew.IsPassword = true;
            txtNew.LeadingIcon = Views.UI.Icons.Lock;
            txtNew.Location = new Point(0, 0);
            txtNew.Margin = new Padding(0);
            txtNew.MaxLength = 64;
            txtNew.Name = "txtNew";
            txtNew.Placeholder = "Choose a new password";
            txtNew.Size = new Size(148, 40);
            txtNew.TabIndex = 1;
            //
            // fieldConfirm
            //
            fieldConfirm.Caption = "Confirm New Password";
            fieldConfirm.Dock = DockStyle.Top;
            fieldConfirm.Location = new Point(328, 0);
            fieldConfirm.Margin = new Padding(0);
            fieldConfirm.Name = "fieldConfirm";
            fieldConfirm.Size = new Size(164, 62);
            fieldConfirm.TabIndex = 2;
            fieldConfirm.Input = txtConfirm;
            //
            // txtConfirm
            //
            txtConfirm.Dock = DockStyle.Fill;
            txtConfirm.IsPassword = true;
            txtConfirm.LeadingIcon = Views.UI.Icons.Lock;
            txtConfirm.Location = new Point(0, 0);
            txtConfirm.Margin = new Padding(0);
            txtConfirm.MaxLength = 64;
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Placeholder = "Type the new password again";
            txtConfirm.Size = new Size(164, 40);
            txtConfirm.TabIndex = 2;
            //
            // securityFooter
            //
            securityFooter.BackColor = Colors.Surface;
            securityFooter.ColumnCount = 2;
            securityFooter.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            securityFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            securityFooter.Controls.Add(btnUpdatePassword, 0, 0);
            securityFooter.Controls.Add(lbPasswordStatus, 1, 0);
            securityFooter.Dock = DockStyle.Fill;
            securityFooter.Location = new Point(0, 142);
            securityFooter.Margin = new Padding(0);
            securityFooter.Name = "securityFooter";
            securityFooter.RowCount = 1;
            securityFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            securityFooter.Size = new Size(492, 58);
            securityFooter.TabIndex = 2;
            //
            // btnUpdatePassword
            //
            btnUpdatePassword.Anchor = AnchorStyles.Left;
            btnUpdatePassword.BackColor = Color.Transparent;
            btnUpdatePassword.Caption = "Update Password";
            btnUpdatePassword.Font = new Font("Lexend SemiBold", 10.5F);
            btnUpdatePassword.ForeColor = Colors.Foreground;
            btnUpdatePassword.Icon = "lock";
            btnUpdatePassword.Location = new Point(0, 10);
            btnUpdatePassword.Margin = new Padding(0, 0, 14, 0);
            btnUpdatePassword.MinimumSize = new Size(170, 0);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Size = new Size(170, 38);
            btnUpdatePassword.TabIndex = 0;
            btnUpdatePassword.Text = "Update Password";
            btnUpdatePassword.Click += btnUpdatePassword_Click;
            //
            // lbPasswordStatus
            //
            lbPasswordStatus.AutoEllipsis = true;
            lbPasswordStatus.BackColor = Colors.Surface;
            lbPasswordStatus.Dock = DockStyle.Fill;
            lbPasswordStatus.Font = new Font("Lexend", 9.5F);
            lbPasswordStatus.ForeColor = Colors.MutedText;
            lbPasswordStatus.Location = new Point(184, 0);
            lbPasswordStatus.Margin = new Padding(0);
            lbPasswordStatus.Name = "lbPasswordStatus";
            lbPasswordStatus.Size = new Size(308, 58);
            lbPasswordStatus.TabIndex = 1;
            lbPasswordStatus.TextAlign = ContentAlignment.MiddleLeft;
            lbPasswordStatus.Visible = false;
            //
            // preferencesCard
            //
            preferencesCard.Border = Colors.Border;
            preferencesCard.Controls.Add(preferences);
            preferencesCard.Dock = DockStyle.Fill;
            preferencesCard.Location = new Point(0, 154);
            preferencesCard.Margin = new Padding(0, 4, 0, 16);
            preferencesCard.Name = "preferencesCard";
            preferencesCard.Padding = new Padding(24, 18, 24, 18);
            preferencesCard.Radius = Theme.RadiusLg;
            preferencesCard.ShowShadow = true;
            preferencesCard.Size = new Size(900, 130);
            preferencesCard.Surface = Colors.Surface;
            preferencesCard.TabIndex = 2;
            //
            // preferences
            //
            preferences.BackColor = Colors.Surface;
            preferences.ColumnCount = 2;
            preferences.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            preferences.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 420F));
            preferences.Controls.Add(lbPreferencesTitle, 0, 0);
            preferences.SetColumnSpan(lbPreferencesTitle, 2);
            preferences.Controls.Add(currencyHost, 0, 1);
            preferences.Controls.Add(cbCulture, 1, 1);
            preferences.Dock = DockStyle.Fill;
            preferences.Location = new Point(24, 18);
            preferences.Margin = new Padding(0);
            preferences.Name = "preferences";
            preferences.RowCount = 2;
            preferences.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            preferences.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            preferences.Size = new Size(852, 94);
            preferences.TabIndex = 0;
            //
            // lbPreferencesTitle
            //
            lbPreferencesTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbPreferencesTitle.AutoSize = true;
            lbPreferencesTitle.BackColor = Colors.Surface;
            lbPreferencesTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbPreferencesTitle.ForeColor = Colors.Foreground;
            lbPreferencesTitle.Location = new Point(0, 0);
            lbPreferencesTitle.Margin = new Padding(0, 0, 0, 12);
            lbPreferencesTitle.Name = "lbPreferencesTitle";
            lbPreferencesTitle.Size = new Size(852, 34);
            lbPreferencesTitle.TabIndex = 0;
            lbPreferencesTitle.Text = "Preferences";
            lbPreferencesTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // currencyHost
            //
            currencyHost.Anchor = AnchorStyles.Left;
            currencyHost.AutoSize = true;
            currencyHost.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            currencyHost.BackColor = Colors.Surface;
            currencyHost.ColumnCount = 1;
            currencyHost.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            currencyHost.Controls.Add(lbCurrencyTitle, 0, 0);
            currencyHost.Controls.Add(lbCurrencyCaption, 0, 1);
            currencyHost.Location = new Point(0, 48);
            currencyHost.Margin = new Padding(0);
            currencyHost.Name = "currencyHost";
            currencyHost.RowCount = 2;
            currencyHost.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            currencyHost.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            currencyHost.Size = new Size(240, 43);
            currencyHost.TabIndex = 1;
            //
            // lbCurrencyTitle
            //
            lbCurrencyTitle.AutoSize = true;
            lbCurrencyTitle.BackColor = Colors.Surface;
            lbCurrencyTitle.Font = new Font("Lexend SemiBold", 12F);
            lbCurrencyTitle.ForeColor = Colors.Foreground;
            lbCurrencyTitle.Location = new Point(0, 0);
            lbCurrencyTitle.Margin = new Padding(0);
            lbCurrencyTitle.Name = "lbCurrencyTitle";
            lbCurrencyTitle.Size = new Size(130, 23);
            lbCurrencyTitle.TabIndex = 0;
            lbCurrencyTitle.Text = "Currency & format";
            //
            // lbCurrencyCaption
            //
            lbCurrencyCaption.AutoSize = true;
            lbCurrencyCaption.BackColor = Colors.Surface;
            lbCurrencyCaption.Font = new Font("Lexend", 9.5F);
            lbCurrencyCaption.ForeColor = Colors.MutedText;
            lbCurrencyCaption.Location = new Point(0, 23);
            lbCurrencyCaption.Margin = new Padding(0);
            lbCurrencyCaption.Name = "lbCurrencyCaption";
            lbCurrencyCaption.Size = new Size(230, 20);
            lbCurrencyCaption.TabIndex = 1;
            lbCurrencyCaption.Text = "How amounts and dates appear across the app.";
            //
            // cbCulture
            //
            cbCulture.Anchor = AnchorStyles.Right;
            cbCulture.Location = new Point(552, 50);
            cbCulture.Margin = new Padding(0);
            cbCulture.Name = "cbCulture";
            cbCulture.Size = new Size(300, 40);
            cbCulture.TabIndex = 2;
            cbCulture.SelectedIndexChanged += cbCulture_SelectedIndexChanged;
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
            header.ResumeLayout(false);
            scrollHost.ResumeLayout(false);
            content.ResumeLayout(false);
            accountCard.ResumeLayout(false);
            account.ResumeLayout(false);
            account.PerformLayout();
            profile.ResumeLayout(false);
            profile.PerformLayout();
            names.ResumeLayout(false);
            names.PerformLayout();
            securityCard.ResumeLayout(false);
            security.ResumeLayout(false);
            security.PerformLayout();
            passwordFields.ResumeLayout(false);
            securityFooter.ResumeLayout(false);
            securityFooter.PerformLayout();
            preferencesCard.ResumeLayout(false);
            preferences.ResumeLayout(false);
            preferences.PerformLayout();
            currencyHost.ResumeLayout(false);
            currencyHost.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private TableLayoutPanel header;
        private Controls.Heading heading1;
        private Panel scrollHost;
        private TableLayoutPanel content;
        private Views.UI.Controls.SectionCard accountCard;
        private TableLayoutPanel account;
        private Label lbAccountTitle;
        private TableLayoutPanel profile;
        private Views.UI.Controls.AvatarView avatar;
        private TableLayoutPanel names;
        private Label lbName;
        private Label lbMeta;
        private Views.UI.Controls.AppButton btnLogout;
        private Views.UI.Controls.SectionCard securityCard;
        private TableLayoutPanel security;
        private Label lbSecurityTitle;
        private TableLayoutPanel passwordFields;
        private Views.UI.Controls.FormField fieldCurrent;
        private Views.UI.Controls.AppTextField txtCurrent;
        private Views.UI.Controls.FormField fieldNew;
        private Views.UI.Controls.AppTextField txtNew;
        private Views.UI.Controls.FormField fieldConfirm;
        private Views.UI.Controls.AppTextField txtConfirm;
        private TableLayoutPanel securityFooter;
        private Views.UI.Controls.AppButton btnUpdatePassword;
        private Label lbPasswordStatus;
        private Views.UI.Controls.SectionCard preferencesCard;
        private TableLayoutPanel preferences;
        private Label lbPreferencesTitle;
        private TableLayoutPanel currencyHost;
        private Label lbCurrencyTitle;
        private Label lbCurrencyCaption;
        private Views.UI.Controls.AppComboField cbCulture;
    }
}
