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
            fieldCategory = new Views.UI.Controls.FormField();
            cbCategory = new Views.UI.Controls.AppComboField();
            fieldType = new Views.UI.Controls.FormField();
            cbType = new Views.UI.Controls.AppComboField();
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
            root.Size = new Size(372, 500);
            root.TabIndex = 0;
            // 
            // heading1
            // 
            heading1.BackColor = Colors.Surface;
            heading1.description = "Add a new income or expense";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(372, 64);
            heading1.TabIndex = 0;
            heading1.Title = "Add Transaction";
            // 
            // fields
            // 
            fields.BackColor = Colors.Surface;
            fields.ColumnCount = 1;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fields.Controls.Add(fieldCategory, 0, 0);
            fields.Controls.Add(fieldType, 0, 1);
            fields.Controls.Add(fieldDescription, 0, 2);
            fields.Dock = DockStyle.Fill;
            fields.Location = new Point(0, 64);
            fields.Margin = new Padding(0);
            fields.Name = "fields";
            fields.RowCount = 3;
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.Size = new Size(372, 386);
            fields.TabIndex = 1;
            // 
            // fieldCategory
            // 
            fieldCategory.Caption = "Category";
            fieldCategory.Dock = DockStyle.Top;
            fieldCategory.Location = new Point(0, 0);
            fieldCategory.Margin = new Padding(0, 0, 0, 16);
            fieldCategory.Name = "fieldCategory";
            fieldCategory.Size = new Size(372, 60);
            fieldCategory.TabIndex = 0;
            fieldCategory.Input = cbCategory;
            // 
            // cbCategory
            // 
            cbCategory.Location = new Point(0, 0);
            cbCategory.Margin = new Padding(0);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(372, 40);
            cbCategory.TabIndex = 0;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // fieldType
            // 
            fieldType.Caption = "Type";
            fieldType.Dock = DockStyle.Top;
            fieldType.Location = new Point(0, 76);
            fieldType.Margin = new Padding(0, 0, 0, 16);
            fieldType.Name = "fieldType";
            fieldType.Size = new Size(372, 60);
            fieldType.TabIndex = 1;
            fieldType.Input = cbType;
            // 
            // cbType
            // 
            cbType.Enabled = false;
            cbType.Location = new Point(0, 0);
            cbType.Margin = new Padding(0);
            cbType.Name = "cbType";
            cbType.Size = new Size(372, 40);
            cbType.TabIndex = 0;
            cbType.Items.AddRange(new object[] { "INCOME", "EXPENSE" });
            // 
            // fieldDescription
            // 
            fieldDescription.Caption = "Description";
            fieldDescription.Dock = DockStyle.Top;
            fieldDescription.Location = new Point(0, 152);
            fieldDescription.Margin = new Padding(0);
            fieldDescription.Name = "fieldDescription";
            fieldDescription.Size = new Size(372, 140);
            fieldDescription.TabIndex = 2;
            fieldDescription.Input = txtDescription;
            txtDescription.Height = 120;
            fieldDescription.SyncInputHeight();
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(0, 0);
            txtDescription.Margin = new Padding(0);
            txtDescription.Multiline = true;
            txtDescription.Placeholder = "Notes (optional)";
            txtDescription.Size = new Size(372, 120);
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
            footer.Location = new Point(0, 450);
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
            btnSubmit.Caption = "Save";
            btnSubmit.Location = new Point(260, 6);
            btnSubmit.Margin = new Padding(0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 38);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Save";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // TransactionDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            ClientSize = new Size(420, 548);
            Controls.Add(root);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TransactionDialog";
            Padding = new Padding(24);
            StartPosition = FormStartPosition.CenterParent;
            Text = "TransactionDialog";
            Load += TransactionDialog_Load;
            root.ResumeLayout(false);
            fields.ResumeLayout(false);
            footer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private TableLayoutPanel fields;
        private Views.UI.Controls.FormField fieldCategory;
        private Views.UI.Controls.AppComboField cbCategory;
        private Views.UI.Controls.FormField fieldType;
        private Views.UI.Controls.AppComboField cbType;
        private Views.UI.Controls.FormField fieldDescription;
        private Views.UI.Controls.AppTextField txtDescription;
        private TableLayoutPanel footer;
        private Views.UI.Controls.AppButton btnCancel;
        private Views.UI.Controls.AppButton btnSubmit;
    }
}
