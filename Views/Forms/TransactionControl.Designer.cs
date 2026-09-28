namespace PersonalExpenseTracker.Views.Forms
{
    partial class TransactionControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel2 = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            btnAddTransaction = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            cardExpense = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardTransaction = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardIncome = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardBalance = new PersonalExpenseTracker.Views.Controls.StatCard();
            dgv = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            textBox1 = new TextBox();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(heading1, 0, 0);
            tableLayoutPanel2.Controls.Add(btnAddTransaction, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(943, 74);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // heading1
            // 
            heading1.AutoSize = true;
            heading1.description = "All your expense and income goes here";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(3, 3);
            heading1.Name = "heading1";
            heading1.Size = new Size(819, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Transactions";
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Anchor = AnchorStyles.None;
            btnAddTransaction.AutoSize = true;
            btnAddTransaction.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddTransaction.Location = new Point(828, 23);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(112, 27);
            btnAddTransaction.TabIndex = 1;
            btnAddTransaction.Text = "Add Transaction";
            btnAddTransaction.UseVisualStyleBackColor = true;
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Controls.Add(dgv, 0, 3);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(949, 614);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Controls.Add(cardExpense, 2, 0);
            tableLayoutPanel3.Controls.Add(cardTransaction, 3, 0);
            tableLayoutPanel3.Controls.Add(cardIncome, 1, 0);
            tableLayoutPanel3.Controls.Add(cardBalance, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 83);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(943, 94);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // cardExpense
            // 
            cardExpense.BorderStyle = BorderStyle.FixedSingle;
            cardExpense.Dock = DockStyle.Fill;
            cardExpense.Location = new Point(473, 3);
            cardExpense.MinimumSize = new Size(200, 90);
            cardExpense.Name = "cardExpense";
            cardExpense.Padding = new Padding(8);
            cardExpense.Size = new Size(229, 90);
            cardExpense.TabIndex = 2;
            cardExpense.Title = "Expense";
            cardExpense.Value = "$750.00";
            // 
            // cardTransaction
            // 
            cardTransaction.BorderStyle = BorderStyle.FixedSingle;
            cardTransaction.Dock = DockStyle.Fill;
            cardTransaction.Location = new Point(708, 3);
            cardTransaction.MinimumSize = new Size(200, 90);
            cardTransaction.Name = "cardTransaction";
            cardTransaction.Padding = new Padding(8);
            cardTransaction.Size = new Size(232, 90);
            cardTransaction.TabIndex = 3;
            cardTransaction.Title = "Transaction";
            cardTransaction.Value = "$420.00";
            // 
            // cardIncome
            // 
            cardIncome.BorderStyle = BorderStyle.FixedSingle;
            cardIncome.Dock = DockStyle.Fill;
            cardIncome.Location = new Point(238, 3);
            cardIncome.MinimumSize = new Size(200, 90);
            cardIncome.Name = "cardIncome";
            cardIncome.Padding = new Padding(8);
            cardIncome.Size = new Size(229, 90);
            cardIncome.TabIndex = 1;
            cardIncome.Title = "Income";
            cardIncome.Value = "$3,200.00";
            // 
            // cardBalance
            // 
            cardBalance.BorderStyle = BorderStyle.FixedSingle;
            cardBalance.Dock = DockStyle.Fill;
            cardBalance.Location = new Point(3, 3);
            cardBalance.MinimumSize = new Size(200, 90);
            cardBalance.Name = "cardBalance";
            cardBalance.Padding = new Padding(8);
            cardBalance.Size = new Size(229, 90);
            cardBalance.TabIndex = 0;
            cardBalance.Title = "Balance";
            cardBalance.Value = "$2,450.00";
            // 
            // dgv
            // 
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.Gainsboro;
            dgv.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = "N/A";
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(3, 218);
            dgv.Name = "dgv";
            dgv.Size = new Size(943, 393);
            dgv.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(943, 74);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(tableLayoutPanel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 183);
            panel2.Name = "panel2";
            panel2.Size = new Size(943, 29);
            panel2.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(943, 29);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(465, 23);
            textBox1.TabIndex = 0;
            // 
            // TransactionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "TransactionControl";
            Size = new Size(949, 614);
            Load += TransactionControl_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Controls.Heading heading1;
        private Button btnAddTransaction;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgv;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Controls.StatCard cardExpense;
        private Controls.StatCard cardTransaction;
        private Controls.StatCard cardIncome;
        private Controls.StatCard cardBalance;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox textBox1;
    }
}
