using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class ChangePasswordDialog
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
            fieldCurrent = new Views.UI.Controls.FormField();
            txtCurrent = new Views.UI.Controls.AppTextField();
            fieldNew = new Views.UI.Controls.FormField();
            txtNew = new Views.UI.Controls.AppTextField();
            fieldConfirm = new Views.UI.Controls.FormField();
            txtConfirm = new Views.UI.Controls.AppTextField();
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
            root.Size = new Size(372, 300);
            root.TabIndex = 0;
            //
            // heading1
            //
            heading1.BackColor = Colors.Surface;
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(372, 64);
            heading1.TabIndex = 0;
            heading1.Title = "Change Password";
            //
            // fields
            //
            fields.BackColor = Colors.Surface;
            fields.ColumnCount = 1;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fields.Controls.Add(fieldCurrent, 0, 0);
            fields.Controls.Add(fieldNew, 0, 1);
            fields.Controls.Add(fieldConfirm, 0, 2);
            fields.Dock = DockStyle.Fill;
            fields.Location = new Point(0, 64);
            fields.Margin = new Padding(0);
            fields.Name = "fields";
            fields.RowCount = 3;
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.Size = new Size(372, 186);
            fields.TabIndex = 1;
            //
            // fieldCurrent
            //
            fieldCurrent.Caption = "Current Password";
            fieldCurrent.Dock = DockStyle.Top;
            fieldCurrent.Location = new Point(0, 0);
            fieldCurrent.Margin = new Padding(0, 0, 0, 16);
            fieldCurrent.Name = "fieldCurrent";
            fieldCurrent.Size = new Size(372, 60);
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
            txtCurrent.Size = new Size(372, 40);
            txtCurrent.TabIndex = 0;
            //
            // fieldNew
            //
            fieldNew.Caption = "New Password";
            fieldNew.Dock = DockStyle.Top;
            fieldNew.Hint = "At least 6 characters.";
            fieldNew.Location = new Point(0, 76);
            fieldNew.Margin = new Padding(0, 0, 0, 16);
            fieldNew.Name = "fieldNew";
            fieldNew.Size = new Size(372, 60);
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
            txtNew.Size = new Size(372, 40);
            txtNew.TabIndex = 0;
            //
            // fieldConfirm
            //
            fieldConfirm.Caption = "Confirm New Password";
            fieldConfirm.Dock = DockStyle.Top;
            fieldConfirm.Location = new Point(0, 152);
            fieldConfirm.Margin = new Padding(0);
            fieldConfirm.Name = "fieldConfirm";
            fieldConfirm.Size = new Size(372, 60);
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
            txtConfirm.Size = new Size(372, 40);
            txtConfirm.TabIndex = 0;
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
            footer.Location = new Point(0, 250);
            footer.Margin = new Padding(0);
            footer.Name = "footer";
            footer.RowCount = 1;
            footer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footer.Size = new Size(372, 50);
            footer.TabIndex = 2;
            //
            // btnCancel
            //
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Caption = "Cancel";
            btnCancel.Location = new Point(160, 6);
            btnCancel.Margin = new Padding(0, 0, 12, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 38);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.Variant = Views.UI.Controls.AppButtonVariant.Secondary;
            btnCancel.Click += btnCancel_Click;
            //
            // btnSubmit
            //
            btnSubmit.Anchor = AnchorStyles.Right;
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.Caption = "Update";
            btnSubmit.Location = new Point(260, 6);
            btnSubmit.Margin = new Padding(0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 38);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Update";
            btnSubmit.Click += btnSubmit_Click;
            //
            // ChangePasswordDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            ClientSize = new Size(420, 348);
            Controls.Add(root);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChangePasswordDialog";
            Padding = new Padding(24);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Password";
            root.ResumeLayout(false);
            fields.ResumeLayout(false);
            footer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private TableLayoutPanel fields;
        private Views.UI.Controls.FormField fieldCurrent;
        private Views.UI.Controls.AppTextField txtCurrent;
        private Views.UI.Controls.FormField fieldNew;
        private Views.UI.Controls.AppTextField txtNew;
        private Views.UI.Controls.FormField fieldConfirm;
        private Views.UI.Controls.AppTextField txtConfirm;
        private TableLayoutPanel footer;
        private Views.UI.Controls.AppButton btnCancel;
        private Views.UI.Controls.AppButton btnSubmit;
    }
}
