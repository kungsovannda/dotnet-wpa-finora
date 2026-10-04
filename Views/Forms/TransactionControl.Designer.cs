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
            filterBar = new TableLayoutPanel();
            txtSearch = new PersonalExpenseTracker.Views.UI.Controls.AppTextField();
            cbType = new PersonalExpenseTracker.Views.UI.Controls.AppComboField();
            cbMethod = new PersonalExpenseTracker.Views.UI.Controls.AppComboField();
            dtFrom = new PersonalExpenseTracker.Views.UI.Controls.DateField();
            dtTo = new PersonalExpenseTracker.Views.UI.Controls.DateField();
            btnClearFilters = new PersonalExpenseTracker.Views.UI.Controls.AppButton();
            gridCard = new PersonalExpenseTracker.Views.UI.Controls.SectionCard();
            empty = new PersonalExpenseTracker.Views.UI.Controls.EmptyState();
            dgv = new DataGridView();
            root.SuspendLayout();
            header.SuspendLayout();
            statRow.SuspendLayout();
            filterBar.SuspendLayout();
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
            root.Controls.Add(filterBar, 0, 2);
            root.Controls.Add(gridCard, 0, 3);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 4;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
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
            cardTransaction.Size = new Size(209, 104);
            cardTransaction.Support = "";
            cardTransaction.TabIndex = 3;
            cardTransaction.Title = "Transactions";
            cardTransaction.Value = "0";
            // 
            // filterBar
            // 
            filterBar.BackColor = Color.FromArgb(248, 248, 247);
            filterBar.ColumnCount = 6;
            // The search box takes whatever is left; every other control is
            // fixed, so a narrow window squeezes the search rather than
            // dropping a filter on the floor.
            filterBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            filterBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
            filterBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            filterBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            filterBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            filterBar.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            filterBar.Controls.Add(txtSearch, 0, 0);
            filterBar.Controls.Add(cbType, 1, 0);
            filterBar.Controls.Add(cbMethod, 2, 0);
            filterBar.Controls.Add(dtFrom, 3, 0);
            filterBar.Controls.Add(dtTo, 4, 0);
            filterBar.Controls.Add(btnClearFilters, 5, 0);
            filterBar.Dock = DockStyle.Fill;
            filterBar.Location = new Point(0, 204);
            filterBar.Margin = new Padding(0);
            filterBar.Name = "filterBar";
            filterBar.RowCount = 1;
            filterBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filterBar.Size = new Size(900, 48);
            filterBar.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.LeadingIcon = "search";
            txtSearch.Location = new Point(0, 4);
            txtSearch.Margin = new Padding(0, 4, 12, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Placeholder = "Search description, merchant or reference";
            txtSearch.Size = new Size(282, 40);
            txtSearch.TabIndex = 0;
            // 
            // cbType
            // 
            cbType.Dock = DockStyle.Fill;
            cbType.Location = new Point(294, 4);
            cbType.Margin = new Padding(0, 4, 12, 4);
            cbType.Name = "cbType";
            cbType.Size = new Size(120, 40);
            cbType.TabIndex = 1;
            cbType.SelectedIndexChanged += CbFilter_SelectedIndexChanged;
            // 
            // cbMethod
            // 
            cbMethod.Dock = DockStyle.Fill;
            cbMethod.Location = new Point(426, 4);
            cbMethod.Margin = new Padding(0, 4, 12, 4);
            cbMethod.Name = "cbMethod";
            cbMethod.Size = new Size(148, 40);
            cbMethod.TabIndex = 2;
            cbMethod.SelectedIndexChanged += CbFilter_SelectedIndexChanged;
            // 
            // dtFrom
            // 
            dtFrom.Dock = DockStyle.Fill;
            dtFrom.Location = new Point(586, 4);
            dtFrom.Margin = new Padding(0, 4, 12, 4);
            dtFrom.Name = "dtFrom";
            dtFrom.Placeholder = "From date";
            dtFrom.Size = new Size(138, 40);
            dtFrom.TabIndex = 3;
            dtFrom.ValueChanged += DtFilter_ValueChanged;
            // 
            // dtTo
            // 
            dtTo.Dock = DockStyle.Fill;
            dtTo.Location = new Point(736, 4);
            dtTo.Margin = new Padding(0, 4, 12, 4);
            dtTo.Name = "dtTo";
            dtTo.Placeholder = "To date";
            dtTo.Size = new Size(138, 40);
            dtTo.TabIndex = 4;
            dtTo.ValueChanged += DtFilter_ValueChanged;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Anchor = AnchorStyles.Right;
            btnClearFilters.BackColor = Color.Transparent;
            btnClearFilters.Caption = "Clear";
            btnClearFilters.Location = new Point(886, 6);
            btnClearFilters.Margin = new Padding(0);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(78, 38);
            btnClearFilters.TabIndex = 5;
            btnClearFilters.Text = "Clear";
            btnClearFilters.Variant = Views.UI.Controls.AppButtonVariant.Secondary;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // gridCard
            // 
            gridCard.BackColor = Color.FromArgb(248, 248, 247);
            gridCard.Border = Color.FromArgb(228, 228, 231);
            gridCard.Controls.Add(empty);
            gridCard.Controls.Add(dgv);
            gridCard.Dock = DockStyle.Fill;
            gridCard.Location = new Point(0, 256);
            gridCard.Margin = new Padding(0, 4, 0, 0);
            gridCard.Name = "gridCard";
            gridCard.Padding = new Padding(16);
            gridCard.Size = new Size(900, 364);
            gridCard.Surface = Color.FromArgb(255, 255, 255);
            gridCard.TabIndex = 3;
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
            empty.Size = new Size(868, 332);
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
            dgv.Size = new Size(868, 332);
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
            filterBar.ResumeLayout(false);
            filterBar.PerformLayout();
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
        private TableLayoutPanel filterBar;
        private Views.UI.Controls.AppTextField txtSearch;
        private Views.UI.Controls.AppComboField cbType;
        private Views.UI.Controls.AppComboField cbMethod;
        private Views.UI.Controls.DateField dtFrom;
        private Views.UI.Controls.DateField dtTo;
        private Views.UI.Controls.AppButton btnClearFilters;
        private Views.UI.Controls.SectionCard gridCard;
        private DataGridView dgv;
        private Views.UI.Controls.EmptyState empty;
    }
}
