using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class CategoryDialog
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
            fieldName = new Views.UI.Controls.FormField();
            txtCategoryName = new Views.UI.Controls.AppTextField();
            fieldType = new Views.UI.Controls.FormField();
            cbType = new Views.UI.Controls.AppComboField();
            fieldEmoji = new Views.UI.Controls.FormField();
            txtEmoji = new Views.UI.Controls.EmojiInput();
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
            heading1.description = "Create a new category";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(372, 64);
            heading1.TabIndex = 0;
            heading1.Title = "Create Category";
            // 
            // fields
            // 
            fields.BackColor = Colors.Surface;
            fields.ColumnCount = 1;
            fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fields.Controls.Add(fieldName, 0, 0);
            fields.Controls.Add(fieldType, 0, 1);
            fields.Controls.Add(fieldEmoji, 0, 2);
            fields.Controls.Add(fieldDescription, 0, 3);
            fields.Dock = DockStyle.Fill;
            fields.Location = new Point(0, 64);
            fields.Margin = new Padding(0);
            fields.Name = "fields";
            fields.RowCount = 4;
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            fields.Size = new Size(372, 386);
            fields.TabIndex = 1;
            // 
            // fieldName
            // 
            fieldName.Caption = "Category name";
            fieldName.Dock = DockStyle.Top;
            fieldName.Location = new Point(0, 0);
            fieldName.Margin = new Padding(0, 0, 0, 16);
            fieldName.Name = "fieldName";
            fieldName.Size = new Size(372, 60);
            fieldName.TabIndex = 0;
            fieldName.Input = txtCategoryName;
            // 
            // txtCategoryName
            // 
            txtCategoryName.LeadingIcon = Views.UI.Icons.Tag;
            txtCategoryName.Location = new Point(0, 0);
            txtCategoryName.Margin = new Padding(0);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Placeholder = "e.g. Groceries";
            txtCategoryName.Size = new Size(372, 40);
            txtCategoryName.TabIndex = 0;
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
            cbType.Location = new Point(0, 0);
            cbType.Margin = new Padding(0);
            cbType.Name = "cbType";
            cbType.Size = new Size(372, 40);
            cbType.TabIndex = 0;
            cbType.Items.AddRange(new object[] { "INCOME", "EXPENSE" });
            // 
            // fieldEmoji
            // 
            fieldEmoji.Caption = "Emoji";
            fieldEmoji.Dock = DockStyle.Top;
            fieldEmoji.Hint = "Click to browse or type an emoji.";
            fieldEmoji.Location = new Point(0, 152);
            fieldEmoji.Margin = new Padding(0, 0, 0, 16);
            fieldEmoji.Name = "fieldEmoji";
            fieldEmoji.Size = new Size(372, 80);
            fieldEmoji.TabIndex = 2;
            fieldEmoji.Input = txtEmoji;
            // 
            // txtEmoji
            // 
            txtEmoji.Location = new Point(0, 0);
            txtEmoji.Margin = new Padding(0);
            txtEmoji.Name = "txtEmoji";
            txtEmoji.Placeholder = "Click to choose an emoji";
            txtEmoji.Size = new Size(372, 40);
            txtEmoji.TabIndex = 0;
            txtEmoji.Click += txtEmoji_Click;
            // 
            // fieldDescription
            // 
            fieldDescription.Caption = "Description";
            fieldDescription.Dock = DockStyle.Top;
            fieldDescription.Location = new Point(0, 248);
            fieldDescription.Margin = new Padding(0);
            fieldDescription.Name = "fieldDescription";
            fieldDescription.Size = new Size(372, 116);
            fieldDescription.TabIndex = 3;
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
            txtDescription.Size = new Size(372, 96);
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
            btnCancel.Click += button1_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Right;
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.Caption = "Create";
            btnSubmit.Location = new Point(260, 6);
            btnSubmit.Margin = new Padding(0);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 38);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Create";
            btnSubmit.Click += button2_Click;
            // 
            // CategoryDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            ClientSize = new Size(420, 548);
            Controls.Add(root);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CategoryDialog";
            Padding = new Padding(24);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Category Dialog";
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
        private Views.UI.Controls.AppTextField txtCategoryName;
        private Views.UI.Controls.FormField fieldType;
        private Views.UI.Controls.AppComboField cbType;
        private Views.UI.Controls.FormField fieldEmoji;
        private Views.UI.Controls.EmojiInput txtEmoji;
        private Views.UI.Controls.FormField fieldDescription;
        private Views.UI.Controls.AppTextField txtDescription;
        private TableLayoutPanel footer;
        private Views.UI.Controls.AppButton btnCancel;
        private Views.UI.Controls.AppButton btnSubmit;
    }
}
