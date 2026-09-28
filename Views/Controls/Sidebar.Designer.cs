namespace PersonalExpenseTracker.Views.Controls
{
    partial class Sidebar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDashboard = new Button();
            btnSetting = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnCategory = new Button();
            btnTransaction = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(140, 30);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnSetting
            // 
            btnSetting.Dock = DockStyle.Top;
            btnSetting.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSetting.Location = new Point(0, 90);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(140, 30);
            btnSetting.TabIndex = 1;
            btnSetting.Text = "Setting";
            btnSetting.TextAlign = ContentAlignment.MiddleLeft;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(150, 395);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSetting);
            panel1.Controls.Add(btnCategory);
            panel1.Controls.Add(btnTransaction);
            panel1.Controls.Add(btnDashboard);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(140, 323);
            panel1.TabIndex = 0;
            // 
            // btnCategory
            // 
            btnCategory.Dock = DockStyle.Top;
            btnCategory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCategory.Location = new Point(0, 60);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(140, 30);
            btnCategory.TabIndex = 2;
            btnCategory.Text = "Category";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnTransaction
            // 
            btnTransaction.Dock = DockStyle.Top;
            btnTransaction.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTransaction.Location = new Point(0, 30);
            btnTransaction.Name = "btnTransaction";
            btnTransaction.Size = new Size(140, 30);
            btnTransaction.TabIndex = 3;
            btnTransaction.Text = "Transaction";
            btnTransaction.TextAlign = ContentAlignment.MiddleLeft;
            btnTransaction.UseVisualStyleBackColor = true;
            btnTransaction.Click += btnTransaction_Click;
            // 
            // Sidebar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(tableLayoutPanel1);
            Name = "Sidebar";
            Size = new Size(150, 395);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnDashboard;
        private Button btnSetting;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnCategory;
        private Button btnTransaction;
    }
}
