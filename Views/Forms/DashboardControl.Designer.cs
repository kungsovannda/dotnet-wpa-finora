namespace PersonalExpenseTracker.Views.Forms
{
    partial class DashboardControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            cardExpense = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardTransaction = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardIncome = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardBalance = new PersonalExpenseTracker.Views.Controls.StatCard();
            tableLayoutPanel2 = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(cardExpense, 2, 0);
            tableLayoutPanel1.Controls.Add(cardTransaction, 3, 0);
            tableLayoutPanel1.Controls.Add(cardIncome, 1, 0);
            tableLayoutPanel1.Controls.Add(cardBalance, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 83);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1091, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // cardExpense
            // 
            cardExpense.BorderStyle = BorderStyle.FixedSingle;
            cardExpense.Dock = DockStyle.Fill;
            cardExpense.Location = new Point(547, 3);
            cardExpense.MinimumSize = new Size(200, 90);
            cardExpense.Name = "cardExpense";
            cardExpense.Padding = new Padding(8);
            cardExpense.Size = new Size(266, 94);
            cardExpense.TabIndex = 2;
            cardExpense.Title = "Expense";
            cardExpense.Value = "$750.00";
            // 
            // cardTransaction
            // 
            cardTransaction.BorderStyle = BorderStyle.FixedSingle;
            cardTransaction.Dock = DockStyle.Fill;
            cardTransaction.Location = new Point(819, 3);
            cardTransaction.MinimumSize = new Size(200, 90);
            cardTransaction.Name = "cardTransaction";
            cardTransaction.Padding = new Padding(8);
            cardTransaction.Size = new Size(269, 94);
            cardTransaction.TabIndex = 3;
            cardTransaction.Title = "Transaction";
            cardTransaction.Value = "$420.00";
            // 
            // cardIncome
            // 
            cardIncome.BorderStyle = BorderStyle.FixedSingle;
            cardIncome.Dock = DockStyle.Fill;
            cardIncome.Location = new Point(275, 3);
            cardIncome.MinimumSize = new Size(200, 90);
            cardIncome.Name = "cardIncome";
            cardIncome.Padding = new Padding(8);
            cardIncome.Size = new Size(266, 94);
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
            cardBalance.Size = new Size(266, 94);
            cardBalance.TabIndex = 0;
            cardBalance.Title = "Balance";
            cardBalance.Value = "$2,450.00";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel2.Controls.Add(heading1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1097, 472);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // heading1
            // 
            heading1.AutoSize = true;
            heading1.description = "This is the dashboard where you can see all your income";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(3, 3);
            heading1.Name = "heading1";
            heading1.Size = new Size(1091, 74);
            heading1.TabIndex = 1;
            heading1.Title = "Dashboard";
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel2);
            Name = "DashboardControl";
            Size = new Size(1097, 472);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Controls.StatCard cardBalance;
        private Controls.StatCard cardTransaction;
        private Controls.StatCard cardExpense;
        private Controls.StatCard cardIncome;
        private TableLayoutPanel tableLayoutPanel2;
        private Controls.Heading heading1;
    }
}
