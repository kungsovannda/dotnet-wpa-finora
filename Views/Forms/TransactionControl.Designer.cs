using PersonalExpenseTracker.Views.UI;

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
            root = new TableLayoutPanel();
            header = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            btnAddTransaction = new PersonalExpenseTracker.Views.UI.Controls.AppButton();
            statRow = new TableLayoutPanel();
            cardBalance = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardIncome = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardExpense = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardTransaction = new PersonalExpenseTracker.Views.Controls.StatCard();
            gridCard = new PersonalExpenseTracker.Views.UI.Controls.SectionCard();
            empty = new PersonalExpenseTracker.Views.UI.Controls.EmptyState();
            dgv = new DataGridView();
            root.SuspendLayout();
            header.SuspendLayout();
            statRow.SuspendLayout();
            gridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Color.FromArgb(248, 248, 247);
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(statRow, 0, 1);
            root.Controls.Add(gridCard, 0, 2);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 3;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(900, 620);
            root.TabIndex = 0;
            // 
            // header
            // 
            header.BackColor = Color.FromArgb(248, 248, 247);
            header.ColumnCount = 2;
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            // AutoSize lets the column follow the button's caption instead of
            // clipping it; the heading keeps whatever space is left.
            header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            header.Controls.Add(heading1, 0, 0);
            header.Controls.Add(btnAddTransaction, 1, 0);
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
            heading1.AutoSize = true;
            heading1.BackColor = Color.FromArgb(248, 248, 247);
            heading1.description = "All your income and expenses in one place.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(744, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Transactions";
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Anchor = AnchorStyles.Right;
            btnAddTransaction.BackColor = Color.Transparent;
            btnAddTransaction.Caption = "Add Transaction";
            btnAddTransaction.Font = new Font("Lexend SemiBold", 10.5F);
            btnAddTransaction.ForeColor = Color.FromArgb(24, 24, 27);
            btnAddTransaction.Icon = "plus";
            btnAddTransaction.Location = new Point(744, 15);
            btnAddTransaction.Margin = new Padding(0);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(174, 38);
            btnAddTransaction.TabIndex = 1;
            btnAddTransaction.Text = "Add Transaction";
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // statRow
            // 
            statRow.BackColor = Color.FromArgb(248, 248, 247);
            statRow.ColumnCount = 4;
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            statRow.Controls.Add(cardBalance, 0, 0);
            statRow.Controls.Add(cardIncome, 1, 0);
            statRow.Controls.Add(cardExpense, 2, 0);
            statRow.Controls.Add(cardTransaction, 3, 0);
            statRow.Dock = DockStyle.Fill;
            statRow.Location = new Point(0, 68);
            statRow.Margin = new Padding(0);
            statRow.Name = "statRow";
            statRow.RowCount = 1;
            statRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            statRow.Size = new Size(900, 120);
            statRow.TabIndex = 1;
            // 
            // cardBalance
            // 
            cardBalance.Dock = DockStyle.Fill;
            cardBalance.Location = new Point(0, 4);
            cardBalance.Margin = new Padding(0, 4, 16, 12);
            cardBalance.MinimumSize = new Size(150, 96);
            cardBalance.Name = "cardBalance";
            cardBalance.Size = new Size(209, 104);
            cardBalance.Support = "";
            cardBalance.TabIndex = 0;
            cardBalance.Title = "Balance";
            cardBalance.Value = "$0.00";
            // 
            // cardIncome
            // 
            cardIncome.Dock = DockStyle.Fill;
            cardIncome.Icon = "trending-up";
            cardIncome.Location = new Point(225, 4);
            cardIncome.Margin = new Padding(0, 4, 16, 12);
            cardIncome.MinimumSize = new Size(150, 96);
            cardIncome.Name = "cardIncome";
            cardIncome.Size = new Size(209, 104);
            cardIncome.Support = "";
            cardIncome.TabIndex = 1;
            cardIncome.Title = "Income";
            cardIncome.Tone = Views.Controls.StatTone.Income;
            cardIncome.Value = "$0.00";
            // 
            // cardExpense
            // 
            cardExpense.Dock = DockStyle.Fill;
            cardExpense.Icon = "trending-down";
            cardExpense.Location = new Point(450, 4);
            cardExpense.Margin = new Padding(0, 4, 16, 12);
            cardExpense.MinimumSize = new Size(150, 96);
            cardExpense.Name = "cardExpense";
            cardExpense.Size = new Size(209, 104);
            cardExpense.Support = "";
            cardExpense.TabIndex = 2;
            cardExpense.Title = "Expense";
            cardExpense.Tone = Views.Controls.StatTone.Expense;
            cardExpense.Value = "$0.00";
            // 
            // cardTransaction
            // 
            cardTransaction.Dock = DockStyle.Fill;
            cardTransaction.Icon = "receipt";
            cardTransaction.Location = new Point(675, 4);
            cardTransaction.Margin = new Padding(0, 4, 0, 12);
            cardTransaction.MinimumSize = new Size(150, 96);
            cardTransaction.Name = "cardTransaction";
            cardTransaction.Size = new Size(225, 104);
            cardTransaction.Support = "";
            cardTransaction.TabIndex = 3;
            cardTransaction.Title = "Transactions";
            cardTransaction.Value = "0";
            // 
            // gridCard
            // 
            gridCard.BackColor = Color.FromArgb(248, 248, 247);
            gridCard.Border = Color.FromArgb(228, 228, 231);
            gridCard.Controls.Add(empty);
            gridCard.Controls.Add(dgv);
            gridCard.Dock = DockStyle.Fill;
            gridCard.Location = new Point(0, 192);
            gridCard.Margin = new Padding(0, 4, 0, 0);
            gridCard.Name = "gridCard";
            gridCard.Padding = new Padding(16);
            gridCard.Size = new Size(900, 428);
            gridCard.Surface = Color.FromArgb(255, 255, 255);
            gridCard.TabIndex = 2;
            // 
            // empty
            // 
            empty.ActionText = "Add Transaction";
            empty.BackColor = Color.FromArgb(255, 255, 255);
            empty.Description = "Record your first income or expense and it will show up here.";
            empty.Dock = DockStyle.Fill;
            empty.Font = new Font("Lexend", 10.5F);
            empty.Icon = "receipt";
            empty.Location = new Point(16, 16);
            empty.Margin = new Padding(0);
            empty.Name = "empty";
            empty.Size = new Size(868, 396);
            empty.TabIndex = 1;
            empty.Title = "No transactions yet";
            empty.Visible = false;
            empty.Click += btnAddTransaction_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.Font = new Font("Lexend SemiBold", 9.5F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(113, 113, 122);
            dataGridViewCellStyle1.Padding = new Padding(12, 0, 12, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(113, 113, 122);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Dock = DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(237, 237, 239);
            dgv.Location = new Point(16, 16);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 44;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(868, 396);
            dgv.TabIndex = 0;
            // 
            // TransactionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 248, 247);
            Controls.Add(root);
            Name = "TransactionControl";
            Size = new Size(900, 620);
            Load += TransactionControl_Load;
            root.ResumeLayout(false);
            header.ResumeLayout(false);
            header.PerformLayout();
            statRow.ResumeLayout(false);
            gridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private TableLayoutPanel header;
        private Controls.Heading heading1;
        private Views.UI.Controls.AppButton btnAddTransaction;
        private TableLayoutPanel statRow;
        private Controls.StatCard cardBalance;
        private Controls.StatCard cardIncome;
        private Controls.StatCard cardExpense;
        private Controls.StatCard cardTransaction;
        private Views.UI.Controls.SectionCard gridCard;
        private DataGridView dgv;
        private Views.UI.Controls.EmptyState empty;
    }
}
