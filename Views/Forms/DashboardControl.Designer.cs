using PersonalExpenseTracker.Views.UI;

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
            root = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            statRow = new TableLayoutPanel();
            cardBalance = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardIncome = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardExpense = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardSavings = new PersonalExpenseTracker.Views.Controls.StatCard();
            body = new TableLayoutPanel();
            overviewCard = new PersonalExpenseTracker.Views.UI.Controls.SectionCard();
            chart = new PersonalExpenseTracker.Views.UI.Controls.MiniBarChart();
            chartHeader = new TableLayoutPanel();
            lbChartTitle = new Label();
            rightCol = new TableLayoutPanel();
            recentCard = new PersonalExpenseTracker.Views.UI.Controls.SectionCard();
            recentEmpty = new PersonalExpenseTracker.Views.UI.Controls.EmptyState();
            recentList = new FlowLayoutPanel();
            recentHeader = new TableLayoutPanel();
            lbRecentTitle = new Label();
            goalCard = new PersonalExpenseTracker.Views.UI.Controls.SectionCard();
            goalList = new FlowLayoutPanel();
            goalEmpty = new PersonalExpenseTracker.Views.UI.Controls.EmptyState();
            goalHeader = new TableLayoutPanel();
            lbGoalTitle = new Label();
            root.SuspendLayout();
            statRow.SuspendLayout();
            body.SuspendLayout();
            overviewCard.SuspendLayout();
            chartHeader.SuspendLayout();
            rightCol.SuspendLayout();
            recentCard.SuspendLayout();
            recentHeader.SuspendLayout();
            goalCard.SuspendLayout();
            goalHeader.SuspendLayout();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Color.FromArgb(248, 248, 247);
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(heading1, 0, 0);
            root.Controls.Add(statRow, 0, 1);
            root.Controls.Add(body, 0, 2);
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
            // heading1
            // 
            heading1.AutoSize = true;
            heading1.BackColor = Color.FromArgb(248, 248, 247);
            heading1.description = "Here is what is happening with your money today.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(900, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Overview";
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
            statRow.Controls.Add(cardSavings, 3, 0);
            statRow.Dock = DockStyle.Fill;
            statRow.Location = new Point(0, 68);
            statRow.Margin = new Padding(0);
            statRow.Name = "statRow";
            statRow.RowCount = 1;
            statRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            statRow.Size = new Size(900, 136);
            statRow.TabIndex = 1;
            // 
            // cardBalance
            // 
            cardBalance.BackColor = Color.FromArgb(248, 248, 247);
            cardBalance.Dock = DockStyle.Fill;
            cardBalance.Location = new Point(0, 4);
            cardBalance.Margin = new Padding(0, 4, 16, 12);
            cardBalance.MinimumSize = new Size(150, 99);
            cardBalance.Name = "cardBalance";
            cardBalance.Padding = new Padding(16, 14, 16, 14);
            cardBalance.Size = new Size(209, 120);
            cardBalance.Support = "";
            cardBalance.TabIndex = 0;
            cardBalance.Title = "Total Balance";
            cardBalance.Value = "$0.00";
            // 
            // cardIncome
            // 
            cardIncome.BackColor = Color.FromArgb(248, 248, 247);
            cardIncome.Dock = DockStyle.Fill;
            cardIncome.Icon = "trending-up";
            cardIncome.Location = new Point(225, 4);
            cardIncome.Margin = new Padding(0, 4, 16, 12);
            cardIncome.MinimumSize = new Size(150, 99);
            cardIncome.Name = "cardIncome";
            cardIncome.Padding = new Padding(16, 14, 16, 14);
            cardIncome.Size = new Size(209, 120);
            cardIncome.Support = "";
            cardIncome.TabIndex = 1;
            cardIncome.Title = "Total Income";
            cardIncome.Tone = Views.Controls.StatTone.Income;
            cardIncome.Value = "$0.00";
            // 
            // cardExpense
            // 
            cardExpense.BackColor = Color.FromArgb(248, 248, 247);
            cardExpense.Dock = DockStyle.Fill;
            cardExpense.Icon = "trending-down";
            cardExpense.Location = new Point(450, 4);
            cardExpense.Margin = new Padding(0, 4, 16, 12);
            cardExpense.MinimumSize = new Size(150, 99);
            cardExpense.Name = "cardExpense";
            cardExpense.Padding = new Padding(16, 14, 16, 14);
            cardExpense.Size = new Size(209, 120);
            cardExpense.Support = "";
            cardExpense.TabIndex = 2;
            cardExpense.Title = "Total Expenses";
            cardExpense.Tone = Views.Controls.StatTone.Expense;
            cardExpense.Value = "$0.00";
            // 
            // cardSavings
            // 
            cardSavings.BackColor = Color.FromArgb(248, 248, 247);
            cardSavings.Dock = DockStyle.Fill;
            cardSavings.Icon = "sparkles";
            cardSavings.Location = new Point(675, 4);
            cardSavings.Margin = new Padding(0, 4, 0, 12);
            cardSavings.MinimumSize = new Size(150, 99);
            cardSavings.Name = "cardSavings";
            cardSavings.Padding = new Padding(16, 14, 16, 14);
            cardSavings.Size = new Size(225, 120);
            cardSavings.Support = "";
            cardSavings.TabIndex = 3;
            cardSavings.Title = "Savings Progress";
            cardSavings.Value = "0%";
            // 
            // body
            // 
            body.BackColor = Color.FromArgb(248, 248, 247);
            body.ColumnCount = 2;
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            body.Controls.Add(overviewCard, 0, 0);
            body.Controls.Add(rightCol, 1, 0);
            body.Dock = DockStyle.Fill;
            body.Location = new Point(0, 204);
            body.Margin = new Padding(0);
            body.Name = "body";
            body.RowCount = 1;
            body.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            body.Size = new Size(900, 416);
            body.TabIndex = 2;
            // 
            // overviewCard
            // 
            overviewCard.BackColor = Color.FromArgb(248, 248, 247);
            overviewCard.Border = Color.FromArgb(228, 228, 231);
            overviewCard.Controls.Add(chart);
            overviewCard.Controls.Add(chartHeader);
            overviewCard.Dock = DockStyle.Fill;
            overviewCard.Location = new Point(0, 4);
            overviewCard.Margin = new Padding(0, 4, 16, 0);
            overviewCard.Name = "overviewCard";
            overviewCard.Padding = new Padding(20, 18, 20, 18);
            overviewCard.Size = new Size(524, 412);
            overviewCard.Surface = Color.FromArgb(255, 255, 255);
            overviewCard.TabIndex = 0;
            // 
            // chart
            // 
            chart.BackColor = Color.Transparent;
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(20, 46);
            chart.Margin = new Padding(0);
            chart.Name = "chart";
            chart.Size = new Size(484, 348);
            chart.TabIndex = 0;
            // 
            // chartHeader
            // 
            chartHeader.ColumnCount = 1;
            chartHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            chartHeader.Controls.Add(lbChartTitle, 0, 0);
            chartHeader.Dock = DockStyle.Top;
            chartHeader.Location = new Point(20, 18);
            chartHeader.Margin = new Padding(0);
            chartHeader.Name = "chartHeader";
            chartHeader.RowCount = 1;
            chartHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            chartHeader.Size = new Size(484, 28);
            chartHeader.TabIndex = 1;
            // 
            // lbChartTitle
            // 
            lbChartTitle.BackColor = Color.White;
            lbChartTitle.Dock = DockStyle.Fill;
            lbChartTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbChartTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbChartTitle.Location = new Point(0, 0);
            lbChartTitle.Margin = new Padding(0);
            lbChartTitle.Name = "lbChartTitle";
            lbChartTitle.Size = new Size(484, 28);
            lbChartTitle.TabIndex = 0;
            lbChartTitle.Text = "Spending Overview";
            lbChartTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rightCol
            // 
            rightCol.BackColor = Color.FromArgb(248, 248, 247);
            rightCol.ColumnCount = 1;
            rightCol.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightCol.Controls.Add(recentCard, 0, 0);
            rightCol.Controls.Add(goalCard, 0, 1);
            rightCol.Dock = DockStyle.Fill;
            rightCol.Location = new Point(540, 0);
            rightCol.Margin = new Padding(0);
            rightCol.Name = "rightCol";
            rightCol.RowCount = 2;
            rightCol.RowStyles.Add(new RowStyle(SizeType.Percent, 62F));
            rightCol.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            rightCol.Size = new Size(360, 416);
            rightCol.TabIndex = 1;
            // 
            // recentCard
            // 
            recentCard.BackColor = Color.FromArgb(248, 248, 247);
            recentCard.Border = Color.FromArgb(228, 228, 231);
            recentCard.Controls.Add(recentEmpty);
            recentCard.Controls.Add(recentList);
            recentCard.Controls.Add(recentHeader);
            recentCard.Dock = DockStyle.Fill;
            recentCard.Location = new Point(0, 4);
            recentCard.Margin = new Padding(0, 4, 0, 0);
            recentCard.Name = "recentCard";
            recentCard.Padding = new Padding(20, 18, 20, 18);
            recentCard.Size = new Size(360, 254);
            recentCard.Surface = Color.FromArgb(255, 255, 255);
            recentCard.TabIndex = 0;
            // 
            // recentEmpty
            // 
            recentEmpty.BackColor = Color.Transparent;
            recentEmpty.Description = "New transactions will appear here as soon as you add them.";
            recentEmpty.Dock = DockStyle.Fill;
            recentEmpty.Font = new Font("Lexend", 10.5F);
            recentEmpty.Icon = "receipt";
            recentEmpty.Location = new Point(20, 46);
            recentEmpty.Margin = new Padding(0);
            recentEmpty.Name = "recentEmpty";
            recentEmpty.Size = new Size(320, 190);
            recentEmpty.TabIndex = 0;
            recentEmpty.Title = "No transactions yet";
            recentEmpty.Visible = false;
            // 
            // recentList
            // 
            recentList.AutoScroll = true;
            recentList.BackColor = Color.FromArgb(255, 255, 255);
            recentList.Dock = DockStyle.Fill;
            recentList.FlowDirection = FlowDirection.TopDown;
            recentList.Location = new Point(20, 46);
            recentList.Margin = new Padding(0);
            recentList.Name = "recentList";
            recentList.Size = new Size(320, 190);
            recentList.TabIndex = 1;
            recentList.WrapContents = false;
            // 
            // recentHeader
            // 
            recentHeader.ColumnCount = 2;
            recentHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            recentHeader.ColumnStyles.Add(new ColumnStyle());
            recentHeader.Controls.Add(lbRecentTitle, 0, 0);
            recentHeader.Dock = DockStyle.Top;
            recentHeader.Location = new Point(20, 18);
            recentHeader.Margin = new Padding(0);
            recentHeader.Name = "recentHeader";
            recentHeader.RowCount = 1;
            recentHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            recentHeader.Size = new Size(320, 28);
            recentHeader.TabIndex = 2;
            // 
            // lbRecentTitle
            // 
            lbRecentTitle.BackColor = Color.White;
            lbRecentTitle.Dock = DockStyle.Fill;
            lbRecentTitle.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbRecentTitle.ForeColor = Color.FromArgb(24, 24, 27);
            lbRecentTitle.Location = new Point(0, 0);
            lbRecentTitle.Margin = new Padding(0);
            lbRecentTitle.Name = "lbRecentTitle";
            lbRecentTitle.Size = new Size(320, 28);
            lbRecentTitle.TabIndex = 0;
            lbRecentTitle.Text = "Recent Transactions";
            lbRecentTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // goalCard
            // 
            goalCard.BackColor = Color.FromArgb(248, 248, 247);
            goalCard.Border = Color.FromArgb(228, 228, 231);
            goalCard.Controls.Add(goalEmpty);
            goalCard.Controls.Add(goalList);
            goalCard.Controls.Add(goalHeader);
            goalCard.Dock = DockStyle.Fill;
            goalCard.Location = new Point(0, 262);
            goalCard.Margin = new Padding(0, 4, 0, 0);
            goalCard.Name = "goalCard";
            goalCard.Padding = new Padding(20, 18, 20, 18);
            goalCard.Size = new Size(360, 150);
            goalCard.Surface = Color.FromArgb(255, 255, 255);
            goalCard.TabIndex = 1;
            // 
            // goalEmpty
            // 
            goalEmpty.BackColor = Color.Transparent;
            goalEmpty.Description = "Set one up and watch it fill up.";
            goalEmpty.Dock = DockStyle.Fill;
            goalEmpty.Font = new Font("Lexend", 10.5F);
            goalEmpty.Icon = "sparkles";
            goalEmpty.Location = new Point(20, 46);
            goalEmpty.Margin = new Padding(0);
            goalEmpty.Name = "goalEmpty";
            goalEmpty.Size = new Size(320, 86);
            goalEmpty.TabIndex = 0;
            goalEmpty.Title = "No saving goals";
            goalEmpty.Visible = false;
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
            goalList.Size = new Size(320, 86);
            goalList.TabIndex = 1;
            goalList.WrapContents = false;
            // 
            // goalHeader
            // 
            goalHeader.ColumnCount = 2;
            goalHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            goalHeader.ColumnStyles.Add(new ColumnStyle());
            goalHeader.Controls.Add(lbGoalTitle, 0, 0);
            goalHeader.Dock = DockStyle.Top;
            goalHeader.Location = new Point(20, 18);
            goalHeader.Margin = new Padding(0);
            goalHeader.Name = "goalHeader";
            goalHeader.RowCount = 1;
            goalHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            goalHeader.Size = new Size(320, 28);
            goalHeader.TabIndex = 2;
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
            lbGoalTitle.Size = new Size(320, 28);
            lbGoalTitle.TabIndex = 0;
            lbGoalTitle.Text = "Saving Goals";
            lbGoalTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 248, 247);
            Controls.Add(root);
            Name = "DashboardControl";
            Size = new Size(900, 620);
            Load += DashboardControl_Load;
            root.ResumeLayout(false);
            root.PerformLayout();
            statRow.ResumeLayout(false);
            body.ResumeLayout(false);
            overviewCard.ResumeLayout(false);
            chartHeader.ResumeLayout(false);
            rightCol.ResumeLayout(false);
            recentCard.ResumeLayout(false);
            recentHeader.ResumeLayout(false);
            goalCard.ResumeLayout(false);
            goalHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private TableLayoutPanel statRow;
        private Controls.StatCard cardBalance;
        private Controls.StatCard cardIncome;
        private Controls.StatCard cardExpense;
        private Controls.StatCard cardSavings;
        private TableLayoutPanel body;
        private Views.UI.Controls.SectionCard overviewCard;
        private Views.UI.Controls.MiniBarChart chart;
        private TableLayoutPanel chartHeader;
        private Label lbChartTitle;
        private TableLayoutPanel rightCol;
        private Views.UI.Controls.SectionCard recentCard;
        private Views.UI.Controls.EmptyState recentEmpty;
        private FlowLayoutPanel recentList;
        private TableLayoutPanel recentHeader;
        private Label lbRecentTitle;
        private Views.UI.Controls.SectionCard goalCard;
        private FlowLayoutPanel goalList;
        private Views.UI.Controls.EmptyState goalEmpty;
        private TableLayoutPanel goalHeader;
        private Label lbGoalTitle;
    }
}
