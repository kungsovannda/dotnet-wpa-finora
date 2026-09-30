using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class ReportControl
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
            header = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            periodHost = new TableLayoutPanel();
            lbPeriod = new Label();
            cbPeriod = new Views.UI.Controls.AppComboField();
            scrollHost = new Panel();
            content = new TableLayoutPanel();
            statRow = new TableLayoutPanel();
            cardIncome = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardExpense = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardNet = new PersonalExpenseTracker.Views.Controls.StatCard();
            midRow = new TableLayoutPanel();
            categoryCard = new Views.UI.Controls.SectionCard();
            categoryHeader = new TableLayoutPanel();
            lbCategoryTitle = new Label();
            categoryList = new FlowLayoutPanel();
            categoryEmpty = new Views.UI.Controls.EmptyState();
            methodCard = new Views.UI.Controls.SectionCard();
            methodHeader = new TableLayoutPanel();
            lbMethodTitle = new Label();
            methodList = new FlowLayoutPanel();
            methodEmpty = new Views.UI.Controls.EmptyState();
            bottomRow = new TableLayoutPanel();
            monthCard = new Views.UI.Controls.SectionCard();
            monthHeader = new TableLayoutPanel();
            lbMonthTitle = new Label();
            monthChart = new Views.UI.Controls.MiniBarChart();
            monthEmpty = new Views.UI.Controls.EmptyState();
            goalCard = new Views.UI.Controls.SectionCard();
            goalHeader = new TableLayoutPanel();
            lbGoalTitle = new Label();
            goalList = new FlowLayoutPanel();
            goalEmpty = new Views.UI.Controls.EmptyState();
            root.SuspendLayout();
            header.SuspendLayout();
            periodHost.SuspendLayout();
            scrollHost.SuspendLayout();
            content.SuspendLayout();
            statRow.SuspendLayout();
            midRow.SuspendLayout();
            categoryCard.SuspendLayout();
            categoryHeader.SuspendLayout();
            methodCard.SuspendLayout();
            methodHeader.SuspendLayout();
            bottomRow.SuspendLayout();
            monthCard.SuspendLayout();
            monthHeader.SuspendLayout();
            goalCard.SuspendLayout();
            goalHeader.SuspendLayout();
            SuspendLayout();
            //
            // root
            //
            root.BackColor = Color.FromArgb(248, 248, 247);
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(scrollHost, 0, 1);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 2;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(900, 620);
            root.TabIndex = 0;
            //
            // header
            //
            header.BackColor = Color.FromArgb(248, 248, 247);
            header.ColumnCount = 2;
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            header.Controls.Add(heading1, 0, 0);
            header.Controls.Add(periodHost, 1, 0);
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
            heading1.BackColor = Color.FromArgb(248, 248, 247);
            heading1.description = "Where your money came from and where it went.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(700, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Reports";
            //
            // periodHost
            //
            periodHost.Anchor = AnchorStyles.Right;
            periodHost.AutoSize = true;
            periodHost.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            periodHost.BackColor = Color.Transparent;
            periodHost.ColumnCount = 2;
            periodHost.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            periodHost.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            periodHost.Controls.Add(lbPeriod, 0, 0);
            periodHost.Controls.Add(cbPeriod, 1, 0);
            periodHost.Location = new Point(716, 18);
            periodHost.Margin = new Padding(0);
            periodHost.Name = "periodHost";
            periodHost.RowCount = 1;
            periodHost.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            periodHost.Size = new Size(184, 40);
            periodHost.TabIndex = 1;
            //
            // lbPeriod
            //
            lbPeriod.Anchor = AnchorStyles.Left;
            lbPeriod.AutoSize = true;
            lbPeriod.BackColor = Color.Transparent;
            lbPeriod.Font = new Font("Lexend", 9.5F);
            lbPeriod.ForeColor = Color.FromArgb(82, 82, 91);
            lbPeriod.Location = new Point(0, 12);
            lbPeriod.Margin = new Padding(0, 0, 12, 0);
            lbPeriod.Name = "lbPeriod";
            lbPeriod.Size = new Size(40, 18);
            lbPeriod.TabIndex = 0;
            lbPeriod.Text = "Period";
            lbPeriod.TextAlign = ContentAlignment.MiddleLeft;
            //
            // cbPeriod
            //
            cbPeriod.Dock = DockStyle.Fill;
            cbPeriod.Location = new Point(52, 0);
            cbPeriod.Margin = new Padding(0);
            cbPeriod.Name = "cbPeriod";
            cbPeriod.Size = new Size(200, 40);
            cbPeriod.TabIndex = 1;
            cbPeriod.SelectedIndexChanged += cbPeriod_SelectedIndexChanged;
            //
            // scrollHost
            //
            scrollHost.AutoScroll = true;
            scrollHost.BackColor = Color.FromArgb(248, 248, 247);
            scrollHost.Controls.Add(content);
            scrollHost.Dock = DockStyle.Fill;
            scrollHost.Location = new Point(0, 68);
            scrollHost.Margin = new Padding(0);
            scrollHost.Name = "scrollHost";
            scrollHost.Size = new Size(900, 552);
            scrollHost.TabIndex = 1;
            //
            // content
            //
            // Rows are fixed rather than proportional: the reports are a
            // scrollable document, so every section keeps its natural height
            // instead of being squashed by the window.
            content.BackColor = Color.FromArgb(248, 248, 247);
            content.ColumnCount = 1;
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            content.Controls.Add(statRow, 0, 0);
            content.Controls.Add(midRow, 0, 1);
            content.Controls.Add(bottomRow, 0, 2);
            content.Dock = DockStyle.Top;
            content.Location = new Point(0, 0);
            content.Margin = new Padding(0);
            content.Name = "content";
            content.RowCount = 3;
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 316F));
            content.Size = new Size(884, 752);
            content.TabIndex = 0;
            //
            // statRow
            //
            statRow.BackColor = Color.FromArgb(248, 248, 247);
            statRow.ColumnCount = 3;
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            statRow.Controls.Add(cardIncome, 0, 0);
            statRow.Controls.Add(cardExpense, 1, 0);
            statRow.Controls.Add(cardNet, 2, 0);
            statRow.Dock = DockStyle.Fill;
            statRow.Location = new Point(0, 0);
            statRow.Margin = new Padding(0);
            statRow.Name = "statRow";
            statRow.RowCount = 1;
            statRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            statRow.Size = new Size(884, 136);
            statRow.TabIndex = 0;
            //
            // cardIncome
            //
            cardIncome.BackColor = Color.FromArgb(248, 248, 247);
            cardIncome.Dock = DockStyle.Fill;
            cardIncome.Icon = "trending-up";
            cardIncome.Location = new Point(0, 4);
            cardIncome.Margin = new Padding(0, 4, 16, 16);
            cardIncome.MinimumSize = new Size(150, 96);
            cardIncome.Name = "cardIncome";
            cardIncome.Size = new Size(279, 116);
            cardIncome.Support = "";
            cardIncome.TabIndex = 0;
            cardIncome.Title = "Income";
            cardIncome.Tone = Views.Controls.StatTone.Income;
            cardIncome.Value = "$0.00";
            //
            // cardExpense
            //
            cardExpense.BackColor = Color.FromArgb(248, 248, 247);
            cardExpense.Dock = DockStyle.Fill;
            cardExpense.Icon = "trending-down";
            cardExpense.Location = new Point(295, 4);
            cardExpense.Margin = new Padding(0, 4, 16, 16);
            cardExpense.MinimumSize = new Size(150, 96);
            cardExpense.Name = "cardExpense";
            cardExpense.Size = new Size(279, 116);
            cardExpense.Support = "";
            cardExpense.TabIndex = 1;
            cardExpense.Title = "Expenses";
            cardExpense.Tone = Views.Controls.StatTone.Expense;
            cardExpense.Value = "$0.00";
            //
            // cardNet
            //
            cardNet.BackColor = Color.FromArgb(248, 248, 247);
            cardNet.Dock = DockStyle.Fill;
            cardNet.Icon = "wallet";
            cardNet.Location = new Point(590, 4);
            cardNet.Margin = new Padding(0, 4, 0, 16);
            cardNet.MinimumSize = new Size(150, 96);
            cardNet.Name = "cardNet";
            cardNet.Size = new Size(294, 116);
            cardNet.Support = "";
            cardNet.TabIndex = 2;
            cardNet.Title = "Net";
            cardNet.Value = "$0.00";
            //
            // midRow
            //
            midRow.BackColor = Color.FromArgb(248, 248, 247);
            midRow.ColumnCount = 2;
            midRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            midRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            midRow.Controls.Add(categoryCard, 0, 0);
            midRow.Controls.Add(methodCard, 1, 0);
            midRow.Dock = DockStyle.Fill;
            midRow.Location = new Point(0, 136);
            midRow.Margin = new Padding(0);
            midRow.Name = "midRow";
            midRow.RowCount = 1;
            midRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            midRow.Size = new Size(884, 300);
            midRow.TabIndex = 1;
            //
            // categoryCard
            //
            categoryCard.BackColor = Color.FromArgb(248, 248, 247);
            categoryCard.Border = Color.FromArgb(228, 228, 231);
            categoryCard.Controls.Add(categoryList);
            categoryCard.Controls.Add(categoryEmpty);
            categoryCard.Controls.Add(categoryHeader);
            categoryCard.Dock = DockStyle.Fill;
            categoryCard.Location = new Point(0, 4);
            categoryCard.Margin = new Padding(0, 4, 16, 0);
            categoryCard.Name = "categoryCard";
            categoryCard.Padding = new Padding(20, 18, 20, 18);
            categoryCard.Size = new Size(426, 296);
            categoryCard.Surface = Color.FromArgb(255, 255, 255);
            categoryCard.TabIndex = 0;
            //
            // categoryHeader
            //
            categoryHeader.ColumnCount = 1;
            categoryHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            categoryHeader.Controls.Add(lbCategoryTitle, 0, 0);
            categoryHeader.Dock = DockStyle.Top;
            categoryHeader.Location = new Point(20, 18);
            categoryHeader.Margin = new Padding(0);
            categoryHeader.Name = "categoryHeader";
            categoryHeader.RowCount = 1;
            categoryHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            categoryHeader.Size = new Size(386, 28);
            categoryHeader.TabIndex = 0;
            //
            // lbCategoryTitle
            //
            lbCategoryTitle.BackColor = Color.White;
            lbCategoryTitle.Dock = DockStyle.Fill;
            lbCategoryTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbCategoryTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbCategoryTitle.Location = new Point(0, 0);
            lbCategoryTitle.Margin = new Padding(0);
            lbCategoryTitle.Name = "lbCategoryTitle";
            lbCategoryTitle.Size = new Size(386, 28);
            lbCategoryTitle.TabIndex = 0;
            lbCategoryTitle.Text = "Expense by Category";
            lbCategoryTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // categoryList
            //
            categoryList.AutoScroll = true;
            categoryList.BackColor = Color.FromArgb(255, 255, 255);
            categoryList.Dock = DockStyle.Fill;
            categoryList.FlowDirection = FlowDirection.TopDown;
            categoryList.Location = new Point(20, 46);
            categoryList.Margin = new Padding(0);
            categoryList.Name = "categoryList";
            categoryList.Size = new Size(386, 232);
            categoryList.TabIndex = 1;
            categoryList.WrapContents = false;
            //
            // categoryEmpty
            //
            categoryEmpty.BackColor = Color.Transparent;
            categoryEmpty.Description = "Expenses recorded in this period will be grouped here.";
            categoryEmpty.Dock = DockStyle.Fill;
            categoryEmpty.Font = new Font("Lexend", 10.5F);
            categoryEmpty.Icon = "categories";
            categoryEmpty.Location = new Point(20, 46);
            categoryEmpty.Margin = new Padding(0);
            categoryEmpty.Name = "categoryEmpty";
            categoryEmpty.Size = new Size(386, 232);
            categoryEmpty.TabIndex = 2;
            categoryEmpty.Title = "No expenses in this period";
            categoryEmpty.Visible = false;
            //
            // methodCard
            //
            methodCard.BackColor = Color.FromArgb(248, 248, 247);
            methodCard.Border = Color.FromArgb(228, 228, 231);
            methodCard.Controls.Add(methodList);
            methodCard.Controls.Add(methodEmpty);
            methodCard.Controls.Add(methodHeader);
            methodCard.Dock = DockStyle.Fill;
            methodCard.Location = new Point(442, 4);
            methodCard.Margin = new Padding(0, 4, 0, 0);
            methodCard.Name = "methodCard";
            methodCard.Padding = new Padding(20, 18, 20, 18);
            methodCard.Size = new Size(442, 296);
            methodCard.Surface = Color.FromArgb(255, 255, 255);
            methodCard.TabIndex = 1;
            //
            // methodHeader
            //
            methodHeader.ColumnCount = 1;
            methodHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            methodHeader.Controls.Add(lbMethodTitle, 0, 0);
            methodHeader.Dock = DockStyle.Top;
            methodHeader.Location = new Point(20, 18);
            methodHeader.Margin = new Padding(0);
            methodHeader.Name = "methodHeader";
            methodHeader.RowCount = 1;
            methodHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            methodHeader.Size = new Size(402, 28);
            methodHeader.TabIndex = 0;
            //
            // lbMethodTitle
            //
            lbMethodTitle.BackColor = Color.White;
            lbMethodTitle.Dock = DockStyle.Fill;
            lbMethodTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbMethodTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbMethodTitle.Location = new Point(0, 0);
            lbMethodTitle.Margin = new Padding(0);
            lbMethodTitle.Name = "lbMethodTitle";
            lbMethodTitle.Size = new Size(402, 28);
            lbMethodTitle.TabIndex = 0;
            lbMethodTitle.Text = "By Payment Method";
            lbMethodTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // methodList
            //
            methodList.AutoScroll = true;
            methodList.BackColor = Color.FromArgb(255, 255, 255);
            methodList.Dock = DockStyle.Fill;
            methodList.FlowDirection = FlowDirection.TopDown;
            methodList.Location = new Point(20, 46);
            methodList.Margin = new Padding(0);
            methodList.Name = "methodList";
            methodList.Size = new Size(402, 232);
            methodList.TabIndex = 1;
            methodList.WrapContents = false;
            //
            // methodEmpty
            //
            methodEmpty.BackColor = Color.Transparent;
            methodEmpty.Description = "How you paid will be totalled here once you record something.";
            methodEmpty.Dock = DockStyle.Fill;
            methodEmpty.Font = new Font("Lexend", 10.5F);
            methodEmpty.Icon = "receipt";
            methodEmpty.Location = new Point(20, 46);
            methodEmpty.Margin = new Padding(0);
            methodEmpty.Name = "methodEmpty";
            methodEmpty.Size = new Size(402, 232);
            methodEmpty.TabIndex = 2;
            methodEmpty.Title = "No transactions in this period";
            methodEmpty.Visible = false;
            //
            // bottomRow
            //
            bottomRow.BackColor = Color.FromArgb(248, 248, 247);
            bottomRow.ColumnCount = 2;
            bottomRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomRow.Controls.Add(monthCard, 0, 0);
            bottomRow.Controls.Add(goalCard, 1, 0);
            bottomRow.Dock = DockStyle.Fill;
            bottomRow.Location = new Point(0, 436);
            bottomRow.Margin = new Padding(0);
            bottomRow.Name = "bottomRow";
            bottomRow.RowCount = 1;
            bottomRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomRow.Size = new Size(884, 316);
            bottomRow.TabIndex = 2;
            //
            // monthCard
            //
            monthCard.BackColor = Color.FromArgb(248, 248, 247);
            monthCard.Border = Color.FromArgb(228, 228, 231);
            monthCard.Controls.Add(monthChart);
            monthCard.Controls.Add(monthEmpty);
            monthCard.Controls.Add(monthHeader);
            monthCard.Dock = DockStyle.Fill;
            monthCard.Location = new Point(0, 4);
            monthCard.Margin = new Padding(0, 4, 16, 0);
            monthCard.Name = "monthCard";
            monthCard.Padding = new Padding(20, 18, 20, 18);
            monthCard.Size = new Size(426, 312);
            monthCard.Surface = Color.FromArgb(255, 255, 255);
            monthCard.TabIndex = 0;
            //
            // monthHeader
            //
            monthHeader.ColumnCount = 1;
            monthHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            monthHeader.Controls.Add(lbMonthTitle, 0, 0);
            monthHeader.Dock = DockStyle.Top;
            monthHeader.Location = new Point(20, 18);
            monthHeader.Margin = new Padding(0);
            monthHeader.Name = "monthHeader";
            monthHeader.RowCount = 1;
            monthHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            monthHeader.Size = new Size(386, 28);
            monthHeader.TabIndex = 0;
            //
            // lbMonthTitle
            //
            lbMonthTitle.BackColor = Color.White;
            lbMonthTitle.Dock = DockStyle.Fill;
            lbMonthTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbMonthTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbMonthTitle.Location = new Point(0, 0);
            lbMonthTitle.Margin = new Padding(0);
            lbMonthTitle.Name = "lbMonthTitle";
            lbMonthTitle.Size = new Size(386, 28);
            lbMonthTitle.TabIndex = 0;
            lbMonthTitle.Text = "Monthly Summary";
            lbMonthTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // monthChart
            //
            monthChart.BackColor = Color.Transparent;
            monthChart.Dock = DockStyle.Fill;
            monthChart.Location = new Point(20, 46);
            monthChart.Margin = new Padding(0);
            monthChart.Name = "monthChart";
            monthChart.Size = new Size(386, 248);
            monthChart.TabIndex = 1;
            //
            // monthEmpty
            //
            monthEmpty.BackColor = Color.Transparent;
            monthEmpty.Description = "Each month of the selected year is charted here as money comes in and goes out.";
            monthEmpty.Dock = DockStyle.Fill;
            monthEmpty.Font = new Font("Lexend", 10.5F);
            monthEmpty.Icon = "reports";
            monthEmpty.Location = new Point(20, 46);
            monthEmpty.Margin = new Padding(0);
            monthEmpty.Name = "monthEmpty";
            monthEmpty.Size = new Size(386, 248);
            monthEmpty.TabIndex = 2;
            monthEmpty.Title = "Nothing recorded this year";
            monthEmpty.Visible = false;
            //
            // goalCard
            //
            goalCard.BackColor = Color.FromArgb(248, 248, 247);
            goalCard.Border = Color.FromArgb(228, 228, 231);
            goalCard.Controls.Add(goalList);
            goalCard.Controls.Add(goalEmpty);
            goalCard.Controls.Add(goalHeader);
            goalCard.Dock = DockStyle.Fill;
            goalCard.Location = new Point(442, 4);
            goalCard.Margin = new Padding(0, 4, 0, 0);
            goalCard.Name = "goalCard";
            goalCard.Padding = new Padding(20, 18, 20, 18);
            goalCard.Size = new Size(442, 312);
            goalCard.Surface = Color.FromArgb(255, 255, 255);
            goalCard.TabIndex = 1;
            //
            // goalHeader
            //
            goalHeader.ColumnCount = 1;
            goalHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            goalHeader.Controls.Add(lbGoalTitle, 0, 0);
            goalHeader.Dock = DockStyle.Top;
            goalHeader.Location = new Point(20, 18);
            goalHeader.Margin = new Padding(0);
            goalHeader.Name = "goalHeader";
            goalHeader.RowCount = 1;
            goalHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            goalHeader.Size = new Size(402, 28);
            goalHeader.TabIndex = 0;
            //
            // lbGoalTitle
            //
            lbGoalTitle.BackColor = Color.White;
            lbGoalTitle.Dock = DockStyle.Fill;
            lbGoalTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbGoalTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbGoalTitle.Location = new Point(0, 0);
            lbGoalTitle.Margin = new Padding(0);
            lbGoalTitle.Name = "lbGoalTitle";
            lbGoalTitle.Size = new Size(402, 28);
            lbGoalTitle.TabIndex = 0;
            lbGoalTitle.Text = "Saving Goal Overview";
            lbGoalTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // goalList
            //
            goalList.AutoScroll = true;
            goalList.BackColor = Color.FromArgb(255, 255, 255);
            goalList.Dock = DockStyle.Fill;
            goalList.FlowDirection = FlowDirection.TopDown;
            goalList.Location = new Point(20, 46);
            goalList.Margin = new Padding(0);
            goalList.Name = "goalList";
            goalList.Size = new Size(402, 248);
            goalList.TabIndex = 1;
            goalList.WrapContents = false;
            //
            // goalEmpty
            //
            goalEmpty.BackColor = Color.Transparent;
            goalEmpty.Description = "Create a saving goal to see how close you are to funding it.";
            goalEmpty.Dock = DockStyle.Fill;
            goalEmpty.Font = new Font("Lexend", 10.5F);
            goalEmpty.Icon = "sparkles";
            goalEmpty.Location = new Point(20, 46);
            goalEmpty.Margin = new Padding(0);
            goalEmpty.Name = "goalEmpty";
            goalEmpty.Size = new Size(402, 248);
            goalEmpty.TabIndex = 2;
            goalEmpty.Title = "No saving goals yet";
            goalEmpty.Visible = false;
            //
            // ReportControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 248, 247);
            Controls.Add(root);
            Name = "ReportControl";
            Size = new Size(900, 620);
            Load += ReportControl_Load;
            root.ResumeLayout(false);
            header.ResumeLayout(false);
            periodHost.ResumeLayout(false);
            periodHost.PerformLayout();
            scrollHost.ResumeLayout(false);
            content.ResumeLayout(false);
            statRow.ResumeLayout(false);
            midRow.ResumeLayout(false);
            categoryCard.ResumeLayout(false);
            categoryHeader.ResumeLayout(false);
            methodCard.ResumeLayout(false);
            methodHeader.ResumeLayout(false);
            bottomRow.ResumeLayout(false);
            monthCard.ResumeLayout(false);
            monthHeader.ResumeLayout(false);
            goalCard.ResumeLayout(false);
            goalHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private TableLayoutPanel header;
        private Controls.Heading heading1;
        private TableLayoutPanel periodHost;
        private Label lbPeriod;
        private Views.UI.Controls.AppComboField cbPeriod;
        private Panel scrollHost;
        private TableLayoutPanel content;
        private TableLayoutPanel statRow;
        private Controls.StatCard cardIncome;
        private Controls.StatCard cardExpense;
        private Controls.StatCard cardNet;
        private TableLayoutPanel midRow;
        private Views.UI.Controls.SectionCard categoryCard;
        private TableLayoutPanel categoryHeader;
        private Label lbCategoryTitle;
        private FlowLayoutPanel categoryList;
        private Views.UI.Controls.EmptyState categoryEmpty;
        private Views.UI.Controls.SectionCard methodCard;
        private TableLayoutPanel methodHeader;
        private Label lbMethodTitle;
        private FlowLayoutPanel methodList;
        private Views.UI.Controls.EmptyState methodEmpty;
        private TableLayoutPanel bottomRow;
        private Views.UI.Controls.SectionCard monthCard;
        private TableLayoutPanel monthHeader;
        private Label lbMonthTitle;
        private Views.UI.Controls.MiniBarChart monthChart;
        private Views.UI.Controls.EmptyState monthEmpty;
        private Views.UI.Controls.SectionCard goalCard;
        private TableLayoutPanel goalHeader;
        private Label lbGoalTitle;
        private FlowLayoutPanel goalList;
        private Views.UI.Controls.EmptyState goalEmpty;
    }
}
