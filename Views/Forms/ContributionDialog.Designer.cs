using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class ContributionDialog
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
            fieldAmount = new Views.UI.Controls.FormField();
            txtAmount = new Views.UI.Controls.AppTextField();
            fieldDate = new Views.UI.Controls.FormField();
            dtDate = new Views.UI.Controls.DateField();
            fieldNote = new Views.UI.Controls.FormField();
            txtNote = new Views.UI.Controls.AppTextField();
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
            heading1.Title = "Add Money";
            //
            // fields
            //
            fields.BackColor = Colors.Surface;
            fields.ColumnCount = 1;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fields.Controls.Add(fieldAmount, 0, 0);
            fields.Controls.Add(fieldDate, 0, 1);
            fields.Controls.Add(fieldNote, 0, 2);
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
            // fieldAmount
            //
            fieldAmount.Caption = "Amount";
            fieldAmount.Dock = DockStyle.Top;
            fieldAmount.Location = new Point(0, 0);
            fieldAmount.Margin = new Padding(0, 0, 0, 16);
            fieldAmount.Name = "fieldAmount";
            fieldAmount.Size = new Size(372, 60);
            fieldAmount.TabIndex = 0;
            fieldAmount.Input = txtAmount;
            //
            // txtAmount
            //
            txtAmount.LeadingIcon = Views.UI.Icons.Wallet;
            txtAmount.Location = new Point(0, 0);
            txtAmount.Margin = new Padding(0);
            txtAmount.MaxLength = 18;
            txtAmount.Name = "txtAmount";
            txtAmount.Placeholder = "0.00";
            txtAmount.Size = new Size(372, 40);
            txtAmount.TabIndex = 0;
            //
            // fieldDate
            //
            fieldDate.Caption = "Date";
            fieldDate.Dock = DockStyle.Top;
            fieldDate.Hint = "Defaults to today.";
            fieldDate.Location = new Point(0, 76);
            fieldDate.Margin = new Padding(0, 0, 0, 16);
            fieldDate.Name = "fieldDate";
            fieldDate.Size = new Size(372, 60);
            fieldDate.TabIndex = 1;
            fieldDate.Input = dtDate;
            //
            // dtDate
            //
            dtDate.Dock = DockStyle.Fill;
            dtDate.Location = new Point(0, 0);
            dtDate.Margin = new Padding(0);
            dtDate.Name = "dtDate";
            dtDate.Placeholder = "Today";
            dtDate.Size = new Size(372, 40);
            dtDate.TabIndex = 0;
            //
            // fieldNote
            //
            fieldNote.Caption = "Note";
            fieldNote.Dock = DockStyle.Top;
            fieldNote.Location = new Point(0, 152);
            fieldNote.Margin = new Padding(0);
            fieldNote.Name = "fieldNote";
            fieldNote.Size = new Size(372, 60);
            fieldNote.TabIndex = 2;
            fieldNote.Input = txtNote;
            //
            // txtNote
            //
            txtNote.Location = new Point(0, 0);
            txtNote.Margin = new Padding(0);
            txtNote.MaxLength = 255;
            txtNote.Name = "txtNote";
            txtNote.Placeholder = "Optional note";
            txtNote.Size = new Size(372, 40);
            txtNote.TabIndex = 0;
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
            btnCancel.Location = new Point(152, 6);
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
            btnSubmit.Caption = "Add Money";
            btnSubmit.Location = new Point(260, 6);
            btnSubmit.Margin = new Padding(0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(124, 38);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Add Money";
            btnSubmit.Click += btnSubmit_Click;
            //
            // ContributionDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            ClientSize = new Size(420, 348);
            Controls.Add(root);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ContributionDialog";
            Padding = new Padding(24);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Contribution Dialog";
            root.ResumeLayout(false);
            fields.ResumeLayout(false);
            footer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private TableLayoutPanel fields;
        private Views.UI.Controls.FormField fieldAmount;
        private Views.UI.Controls.AppTextField txtAmount;
        private Views.UI.Controls.FormField fieldDate;
        private Views.UI.Controls.DateField dtDate;
        private Views.UI.Controls.FormField fieldNote;
        private Views.UI.Controls.AppTextField txtNote;
        private TableLayoutPanel footer;
        private Views.UI.Controls.AppButton btnCancel;
        private Views.UI.Controls.AppButton btnSubmit;
    }
}
