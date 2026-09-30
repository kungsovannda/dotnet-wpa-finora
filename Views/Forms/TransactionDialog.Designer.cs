using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class TransactionDialog
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            root = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            fields = new TableLayoutPanel();
            fieldAmount = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            txtAmount = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            fieldCategory = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            cbCategory = new PersonalExpenseTracker.Views.UI.Controls.AppComboField();
            fieldType = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            txtType = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            fieldPaymentMethod = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            cbPaymentMethod = new PersonalExpenseTracker.Views.UI.Controls.AppComboField();
            fieldDate = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            dtDate = new PersonalExpenseTracker.Views.UI.Controls.DateField();
            fieldMerchant = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            txtMerchant = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            fieldReference = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            txtReference = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            fieldDescription = new PersonalExpenseTracker.Views.UI.Controls.FormField();
            txtDescription = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            footer = new TableLayoutPanel();
            btnCancel = new PersonalExpenseTracker.Views.UI.Controls.AppButton();
            btnSubmit = new PersonalExpenseTracker.Views.UI.Controls.AppButton();
            root.SuspendLayout();
            fields.SuspendLayout();
            footer.SuspendLayout();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Color.FromArgb(255, 255, 255);
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
            root.Size = new Size(568, 674);
            root.TabIndex = 0;
            // 
            // heading1
            // 
            heading1.AutoSize = true;
            heading1.BackColor = Color.FromArgb(255, 255, 255);
            heading1.description = "Add a new income or expense";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(568, 64);
            heading1.TabIndex = 0;
            heading1.Title = "Add Transaction";
            // 
            // fields
            // 
            fields.BackColor = Color.FromArgb(255, 255, 255);
            fields.ColumnCount = 2;
            // The amount, category, type and description rows span both columns;
            // the short metadata pairs share one row to keep the dialog compact.
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fields.Controls.Add(fieldAmount, 0, 0);
            fields.SetColumnSpan(fieldAmount, 2);
            fields.Controls.Add(fieldCategory, 0, 1);
            fields.SetColumnSpan(fieldCategory, 2);
            fields.Controls.Add(fieldType, 0, 2);
            fields.SetColumnSpan(fieldType, 2);
            fields.Controls.Add(fieldPaymentMethod, 0, 3);
            fields.Controls.Add(fieldDate, 1, 3);
            fields.Controls.Add(fieldMerchant, 0, 4);
            fields.Controls.Add(fieldReference, 1, 4);
            fields.Controls.Add(fieldDescription, 0, 5);
            fields.SetColumnSpan(fieldDescription, 2);
            fields.Dock = DockStyle.Fill;
            fields.Location = new Point(0, 64);
            fields.Margin = new Padding(0);
            fields.Name = "fields";
            fields.RowCount = 6;
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.Size = new Size(568, 560);
            fields.TabIndex = 1;
            // 
            // fieldAmount
            // 
            fieldAmount.AutoSize = true;
            fieldAmount.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldAmount.BackColor = Color.Transparent;
            fieldAmount.Caption = "Amount";
            fieldAmount.Dock = DockStyle.Fill;
            fieldAmount.Hint = "Use a positive value, e.g. 120.50";
            fieldAmount.Location = new Point(0, 0);
            fieldAmount.Margin = new Padding(0, 0, 0, 16);
            fieldAmount.Name = "fieldAmount";
            fieldAmount.Size = new Size(568, 82);
            fieldAmount.TabIndex = 0;
            fieldAmount.Input = txtAmount;
            // 
            // txtAmount
            // 
            txtAmount.Dock = DockStyle.Fill;
            txtAmount.LeadingIcon = "wallet";
            txtAmount.Location = new Point(0, 22);
            txtAmount.Margin = new Padding(0);
            txtAmount.MaxLength = 18;
            txtAmount.Name = "txtAmount";
            txtAmount.Placeholder = "0.00";
            txtAmount.Size = new Size(568, 40);
            txtAmount.TabIndex = 0;
            txtAmount.TabStop = false;
            // 
            // fieldCategory
            // 
            fieldCategory.AutoSize = true;
            fieldCategory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldCategory.BackColor = Color.Transparent;
            fieldCategory.Caption = "Category";
            fieldCategory.Dock = DockStyle.Fill;
            fieldCategory.Location = new Point(0, 98);
            fieldCategory.Margin = new Padding(0, 0, 0, 16);
            fieldCategory.Name = "fieldCategory";
            fieldCategory.Size = new Size(568, 62);
            fieldCategory.TabIndex = 1;
            fieldCategory.Input = cbCategory;
            // 
            // cbCategory
            // 
            cbCategory.Dock = DockStyle.Fill;
            cbCategory.Location = new Point(0, 22);
            cbCategory.Margin = new Padding(0);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(568, 40);
            cbCategory.TabIndex = 0;
            cbCategory.TabStop = false;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // fieldType
            // 
            fieldType.AutoSize = true;
            fieldType.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldType.BackColor = Color.Transparent;
            fieldType.Caption = "Type";
            fieldType.Dock = DockStyle.Fill;
            fieldType.Location = new Point(0, 176);
            fieldType.Margin = new Padding(0, 0, 0, 16);
            fieldType.Name = "fieldType";
            fieldType.Size = new Size(568, 62);
            fieldType.TabIndex = 2;
            fieldType.Input = txtType;
            // 
            // txtType
            // 
            txtType.Dock = DockStyle.Fill;
            txtType.LeadingIcon = "trending-up";
            txtType.Location = new Point(0, 22);
            txtType.Margin = new Padding(0);
            txtType.Name = "txtType";
            txtType.Placeholder = "Taken from the category";
            txtType.ReadOnly = true;
            txtType.Size = new Size(568, 40);
            txtType.TabIndex = 0;
            txtType.TabStop = false;
            // 
            // fieldPaymentMethod
            // 
            fieldPaymentMethod.AutoSize = true;
            fieldPaymentMethod.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldPaymentMethod.BackColor = Color.Transparent;
            fieldPaymentMethod.Caption = "Payment Method";
            fieldPaymentMethod.Dock = DockStyle.Fill;
            fieldPaymentMethod.Location = new Point(0, 254);
            fieldPaymentMethod.Margin = new Padding(0, 0, 12, 16);
            fieldPaymentMethod.Name = "fieldPaymentMethod";
            fieldPaymentMethod.Size = new Size(272, 62);
            fieldPaymentMethod.TabIndex = 3;
            fieldPaymentMethod.Input = cbPaymentMethod;
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.Dock = DockStyle.Fill;
            cbPaymentMethod.Location = new Point(0, 22);
            cbPaymentMethod.Margin = new Padding(0);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(272, 40);
            cbPaymentMethod.TabIndex = 0;
            cbPaymentMethod.TabStop = false;
            // 
            // fieldDate
            // 
            fieldDate.AutoSize = true;
            fieldDate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldDate.BackColor = Color.Transparent;
            fieldDate.Caption = "Date & Time";
            fieldDate.Dock = DockStyle.Fill;
            fieldDate.Location = new Point(284, 254);
            fieldDate.Margin = new Padding(0, 0, 0, 16);
            fieldDate.Name = "fieldDate";
            fieldDate.Size = new Size(284, 62);
            fieldDate.TabIndex = 4;
            fieldDate.Input = dtDate;
            // 
            // dtDate
            // 
            dtDate.Dock = DockStyle.Fill;
            dtDate.Location = new Point(0, 22);
            dtDate.Margin = new Padding(0);
            dtDate.Name = "dtDate";
            dtDate.Placeholder = "Today";
            dtDate.ShowTime = true;
            dtDate.Size = new Size(284, 40);
            dtDate.TabIndex = 0;
            dtDate.TabStop = false;
            // 
            // fieldMerchant
            // 
            fieldMerchant.AutoSize = true;
            fieldMerchant.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldMerchant.BackColor = Color.Transparent;
            fieldMerchant.Caption = "Merchant";
            fieldMerchant.Dock = DockStyle.Fill;
            fieldMerchant.Location = new Point(0, 332);
            fieldMerchant.Margin = new Padding(0, 0, 12, 16);
            fieldMerchant.Name = "fieldMerchant";
            fieldMerchant.Size = new Size(272, 62);
            fieldMerchant.TabIndex = 5;
            fieldMerchant.Input = txtMerchant;
            // 
            // txtMerchant
            // 
            txtMerchant.Dock = DockStyle.Fill;
            txtMerchant.LeadingIcon = "tag";
            txtMerchant.Location = new Point(0, 22);
            txtMerchant.Margin = new Padding(0);
            txtMerchant.MaxLength = 120;
            txtMerchant.Name = "txtMerchant";
            txtMerchant.Placeholder = "Optional";
            txtMerchant.Size = new Size(272, 40);
            txtMerchant.TabIndex = 0;
            txtMerchant.TabStop = false;
            // 
            // fieldReference
            // 
            fieldReference.AutoSize = true;
            fieldReference.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldReference.BackColor = Color.Transparent;
            fieldReference.Caption = "Reference";
            fieldReference.Dock = DockStyle.Fill;
            fieldReference.Location = new Point(284, 332);
            fieldReference.Margin = new Padding(0, 0, 0, 16);
            fieldReference.Name = "fieldReference";
            fieldReference.Size = new Size(284, 62);
            fieldReference.TabIndex = 6;
            fieldReference.Input = txtReference;
            // 
            // txtReference
            // 
            txtReference.Dock = DockStyle.Fill;
            txtReference.LeadingIcon = "receipt";
            txtReference.Location = new Point(0, 22);
            txtReference.Margin = new Padding(0);
            txtReference.MaxLength = 64;
            txtReference.Name = "txtReference";
            txtReference.Placeholder = "Optional";
            txtReference.Size = new Size(284, 40);
            txtReference.TabIndex = 0;
            txtReference.TabStop = false;
            // 
            // fieldDescription
            // 
            fieldDescription.AutoSize = true;
            fieldDescription.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldDescription.BackColor = Color.Transparent;
            fieldDescription.Caption = "Description";
            fieldDescription.Dock = DockStyle.Fill;
            fieldDescription.Location = new Point(0, 410);
            fieldDescription.Margin = new Padding(0);
            fieldDescription.Name = "fieldDescription";
            fieldDescription.Size = new Size(568, 118);
            fieldDescription.TabIndex = 7;
            fieldDescription.Input = txtDescription;
            // 
            // txtDescription
            // 
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Location = new Point(0, 22);
            txtDescription.Margin = new Padding(0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Placeholder = "What was this for?";
            txtDescription.Size = new Size(568, 96);
            txtDescription.TabIndex = 0;
            txtDescription.TabStop = false;
            fieldDescription.SyncInputHeight();
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
            footer.Location = new Point(0, 624);
            footer.Margin = new Padding(0);
            footer.Name = "footer";
            footer.RowCount = 1;
            footer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footer.Size = new Size(568, 50);
            footer.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Caption = "Cancel";
            btnCancel.Font = new Font("Lexend SemiBold", 10.5F);
            btnCancel.ForeColor = Color.FromArgb(24, 24, 27);
            btnCancel.Location = new Point(410, 6);
            btnCancel.Margin = new Padding(0, 0, 12, 0);
            btnCancel.MinimumSize = new Size(80, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 38);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.Variant = UI.Controls.AppButtonVariant.Secondary;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Right;
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.Caption = "Save";
            btnSubmit.Font = new Font("Lexend SemiBold", 10.5F);
            btnSubmit.ForeColor = Color.FromArgb(24, 24, 27);
            btnSubmit.Location = new Point(502, 6);
            btnSubmit.Margin = new Padding(0);
            btnSubmit.MinimumSize = new Size(66, 0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(66, 38);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Save";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // TransactionDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 255);
            ClientSize = new Size(616, 722);
            Controls.Add(root);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TransactionDialog";
            Padding = new Padding(24);
            StartPosition = FormStartPosition.CenterParent;
            Text = "TransactionDialog";
            Load += TransactionDialog_Load;
            root.ResumeLayout(false);
            root.PerformLayout();
            fields.ResumeLayout(false);
            fields.PerformLayout();
            footer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private TableLayoutPanel fields;
        private Views.UI.Controls.FormField fieldAmount;
        private Views.UI.Controls.AppTextField txtAmount;
        private Views.UI.Controls.FormField fieldCategory;
        private Views.UI.Controls.AppComboField cbCategory;
        private Views.UI.Controls.FormField fieldType;
        private Views.UI.Controls.AppTextField txtType;
        private Views.UI.Controls.FormField fieldPaymentMethod;
        private Views.UI.Controls.AppComboField cbPaymentMethod;
        private Views.UI.Controls.FormField fieldDate;
        private Views.UI.Controls.DateField dtDate;
        private Views.UI.Controls.FormField fieldMerchant;
        private Views.UI.Controls.AppTextField txtMerchant;
        private Views.UI.Controls.FormField fieldReference;
        private Views.UI.Controls.AppTextField txtReference;
        private Views.UI.Controls.FormField fieldDescription;
        private Views.UI.Controls.AppTextField txtDescription;
        private TableLayoutPanel footer;
        private Views.UI.Controls.AppButton btnCancel;
        private Views.UI.Controls.AppButton btnSubmit;
    }
}
