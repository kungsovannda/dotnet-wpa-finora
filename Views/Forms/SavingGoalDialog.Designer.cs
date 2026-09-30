using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class SavingGoalDialog
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
            fields = new TableLayoutPanel();
            fieldName = new Views.UI.Controls.FormField();
            txtName = new Views.UI.Controls.AppTextField();
            fieldTarget = new Views.UI.Controls.FormField();
            txtTargetAmount = new Views.UI.Controls.AppTextField();
            fieldEmoji = new Views.UI.Controls.FormField();
            txtEmoji = new Views.UI.Controls.EmojiInput();
            fieldTargetDate = new Views.UI.Controls.FormField();
            dtTargetDate = new Views.UI.Controls.DateField();
            fieldDescription = new Views.UI.Controls.FormField();
            txtDescription = new Views.UI.Controls.AppTextField();
            footer = new TableLayoutPanel();
            btnCancel = new Views.UI.Controls.AppButton();
            btnSubmit = new Views.UI.Controls.AppButton();
            root.SuspendLayout();
            fields.SuspendLayout();
            footer.SuspendLayout();
            SuspendLayout();
            //
            // root
            //
            root.BackColor = Colors.Surface;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(heading1, 0, 0);
            root.Controls.Add(fields, 0, 1);
            root.Controls.Add(footer, 0, 2);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(24, 24);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 3;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            root.Size = new Size(396, 602);
            root.TabIndex = 0;
            //
            // heading1
            //
            heading1.BackColor = Colors.Surface;
            heading1.description = "Create a new saving goal";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(396, 64);
            heading1.TabIndex = 0;
            heading1.Title = "New Saving Goal";
            //
            // fields
            //
            fields.BackColor = Colors.Surface;
            // Scroll rather than clip: the five fields need more height than a
            // small window can offer, and a cropped input is unreadable.
            fields.AutoScroll = true;
            fields.ColumnCount = 1;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fields.Controls.Add(fieldName, 0, 0);
            fields.Controls.Add(fieldTarget, 0, 1);
            fields.Controls.Add(fieldEmoji, 0, 2);
            fields.Controls.Add(fieldTargetDate, 0, 3);
            fields.Controls.Add(fieldDescription, 0, 4);
            fields.Dock = DockStyle.Fill;
            fields.Location = new Point(0, 64);
            fields.Margin = new Padding(0);
            fields.Name = "fields";
            fields.RowCount = 5;
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.Size = new Size(396, 488);
            fields.TabIndex = 1;
            //
            // fieldName
            //
            fieldName.Caption = "Goal name";
            fieldName.Dock = DockStyle.Top;
            fieldName.Location = new Point(0, 0);
            fieldName.Margin = new Padding(0, 0, 0, 16);
            fieldName.Name = "fieldName";
            fieldName.Size = new Size(396, 60);
            fieldName.TabIndex = 0;
            fieldName.Input = txtName;
            //
            // txtName
            //
            txtName.LeadingIcon = Views.UI.Icons.Tag;
            txtName.Location = new Point(0, 0);
            txtName.Margin = new Padding(0);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Placeholder = "e.g. Emergency Fund";
            txtName.Size = new Size(396, 40);
            txtName.TabIndex = 0;
            //
            // fieldTarget
            //
            fieldTarget.Caption = "Target amount";
            fieldTarget.Dock = DockStyle.Top;
            fieldTarget.Location = new Point(0, 76);
            fieldTarget.Margin = new Padding(0, 0, 0, 16);
            fieldTarget.Name = "fieldTarget";
            fieldTarget.Size = new Size(396, 60);
            fieldTarget.TabIndex = 1;
            fieldTarget.Input = txtTargetAmount;
            //
            // txtTargetAmount
            //
            txtTargetAmount.LeadingIcon = Views.UI.Icons.Wallet;
            txtTargetAmount.Location = new Point(0, 0);
            txtTargetAmount.Margin = new Padding(0);
            txtTargetAmount.MaxLength = 18;
            txtTargetAmount.Name = "txtTargetAmount";
            txtTargetAmount.Placeholder = "0.00";
            txtTargetAmount.Size = new Size(396, 40);
            txtTargetAmount.TabIndex = 0;
            //
            // fieldEmoji
            //
            fieldEmoji.Caption = "Emoji";
            fieldEmoji.Dock = DockStyle.Top;
            fieldEmoji.Hint = "Click to browse or type an emoji.";
            fieldEmoji.Location = new Point(0, 152);
            fieldEmoji.Margin = new Padding(0, 0, 0, 16);
            fieldEmoji.Name = "fieldEmoji";
            fieldEmoji.Size = new Size(396, 80);
            fieldEmoji.TabIndex = 2;
            fieldEmoji.Input = txtEmoji;
            //
            // txtEmoji
            //
            txtEmoji.Location = new Point(0, 0);
            txtEmoji.Margin = new Padding(0);
            txtEmoji.Name = "txtEmoji";
            txtEmoji.Placeholder = "Click to choose an emoji";
            txtEmoji.Size = new Size(396, 40);
            txtEmoji.TabIndex = 0;
            txtEmoji.Click += txtEmoji_Click;
            //
            // fieldTargetDate
            //
            fieldTargetDate.Caption = "Target date";
            fieldTargetDate.Dock = DockStyle.Top;
            fieldTargetDate.Hint = "Leave as-is for no deadline. A date in the past marks the goal overdue.";
            fieldTargetDate.Location = new Point(0, 248);
            fieldTargetDate.Margin = new Padding(0, 0, 0, 16);
            fieldTargetDate.Name = "fieldTargetDate";
            fieldTargetDate.Size = new Size(396, 60);
            fieldTargetDate.TabIndex = 3;
            fieldTargetDate.Input = dtTargetDate;
            //
            // dtTargetDate
            //
            dtTargetDate.Dock = DockStyle.Fill;
            dtTargetDate.Location = new Point(0, 0);
            dtTargetDate.Margin = new Padding(0);
            dtTargetDate.Name = "dtTargetDate";
            dtTargetDate.Placeholder = "No deadline";
            dtTargetDate.Size = new Size(396, 40);
            dtTargetDate.TabIndex = 0;
            //
            // fieldDescription
            //
            fieldDescription.Caption = "Description";
            fieldDescription.Dock = DockStyle.Top;
            fieldDescription.Location = new Point(0, 324);
            fieldDescription.Margin = new Padding(0);
            fieldDescription.Name = "fieldDescription";
            fieldDescription.Size = new Size(396, 116);
            fieldDescription.TabIndex = 4;
            fieldDescription.Input = txtDescription;
            txtDescription.Height = 96;
            fieldDescription.SyncInputHeight();
            //
            // txtDescription
            //
            txtDescription.Location = new Point(0, 0);
            txtDescription.Margin = new Padding(0);
            txtDescription.Multiline = true;
            txtDescription.Placeholder = "Optional notes";
            txtDescription.Size = new Size(396, 96);
            txtDescription.TabIndex = 0;
            //
            // footer
            //
            footer.ColumnCount = 3;
            footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            footer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            footer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            footer.Controls.Add(btnCancel, 1, 0);
            footer.Controls.Add(btnSubmit, 2, 0);
            footer.Dock = DockStyle.Fill;
            footer.Location = new Point(0, 552);
            footer.Margin = new Padding(0);
            footer.Name = "footer";
            footer.RowCount = 1;
            footer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footer.Size = new Size(396, 50);
            footer.TabIndex = 2;
            //
            // btnCancel
            //
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Caption = "Cancel";
            btnCancel.Location = new Point(164, 6);
            btnCancel.Margin = new Padding(0, 0, 12, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 38);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.Variant = Views.UI.Controls.AppButtonVariant.Secondary;
            btnCancel.Click += btnCancel_Click;
            //
            // btnSubmit
            //
            btnSubmit.Anchor = AnchorStyles.Right;
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.Caption = "Create";
            btnSubmit.Location = new Point(272, 6);
            btnSubmit.Margin = new Padding(0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 38);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Create";
            btnSubmit.Click += btnSubmit_Click;
            //
            // SavingGoalDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            ClientSize = new Size(444, 650);
            Controls.Add(root);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SavingGoalDialog";
            Padding = new Padding(24);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Saving Goal Dialog";
            root.ResumeLayout(false);
            fields.ResumeLayout(false);
            footer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private TableLayoutPanel fields;
        private Views.UI.Controls.FormField fieldName;
        private Views.UI.Controls.AppTextField txtName;
        private Views.UI.Controls.FormField fieldTarget;
        private Views.UI.Controls.AppTextField txtTargetAmount;
        private Views.UI.Controls.FormField fieldEmoji;
        private Views.UI.Controls.EmojiInput txtEmoji;
        private Views.UI.Controls.FormField fieldTargetDate;
        private Views.UI.Controls.DateField dtTargetDate;
        private Views.UI.Controls.FormField fieldDescription;
        private Views.UI.Controls.AppTextField txtDescription;
        private TableLayoutPanel footer;
        private Views.UI.Controls.AppButton btnCancel;
        private Views.UI.Controls.AppButton btnSubmit;
    }
}
