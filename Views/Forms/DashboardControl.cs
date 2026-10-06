using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Dashboard;
using PersonalExpenseTracker.Features.SavingGoals;
using PersonalExpenseTracker.Views.Data;
using PersonalExpenseTracker.Views.UI;
using PersonalExpenseTracker.Views.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    public partial class DashboardControl : UserControl, IRefreshablePage
    {
        private readonly DashboardController _controller;
        private readonly ReportsController _reportsController;
        private readonly SavingGoalController _savingGoalController;
        private readonly DataChangeNotifier _changes;

        /// <summary>Guards against a refresh that somehow triggers another one.</summary>
        private bool _refreshing;

        public DashboardControl(
            DashboardController controller,
            ReportsController reportsController,
            SavingGoalController savingGoalController,
            DataChangeNotifier changes)
        {
            InitializeComponent();
            _controller = controller;
            _reportsController = reportsController;
            _savingGoalController = savingGoalController;
            _changes = changes;
            recentList.ClientSizeChanged += (_, _) => FlowList.FitRows(recentList);
            goalList.ClientSizeChanged += (_, _) => FlowList.FitRows(goalList);

            // The dashboard renders transactions, their categories, the monthly
            // report and the saving goals, so any write can invalidate it. When it
            // is not the page on screen it simply does not repaint; MainForm
            // re-queries it on arrival instead.
            _changes.Changed += Changes_Changed;
            Disposed += DashboardControl_Disposed;
        }

        /// <summary>
        /// Re-reads every figure on the dashboard. This is the only place the
        /// page loads, so the first show and every later visit render from
        /// exactly the same code.
        /// </summary>
        public void RefreshData()
        {
            if (_refreshing || IsDisposed || !IsHandleCreated)
                return;

            _refreshing = true;
            try
            {
                LoadSummary();
                LoadChart();
                LoadRecent();
                LoadGoals();
            }
            finally
            {
                _refreshing = false;
            }
        }

        private void Changes_Changed(object? sender, DataChangedEventArgs e)
        {
            if (IsDisposed || Disposing)
                return;

            // Category renames show up in the recent-transaction rows too, and a
            // contribution moves the savings figures.
            if (e.Change == DataChange.None)
                return;

            if (Visible)
                RefreshData();
        }

        /// <summary>
        /// Unhooks from the shared notifier. Subscribing to Disposed rather than
        /// overriding Dispose keeps the designer's own partial out of the way.
        /// </summary>
        private void DashboardControl_Disposed(object? sender, EventArgs e)
        {
            _changes.Changed -= Changes_Changed;
        }

        private void LoadSummary()
        {
            var summary = _controller.GetDashboardSummary();

            cardBalance.Value = summary.TotalBalance.ToString("C");
            cardBalance.Support = summary.TransactionCount == 1
                ? "1 transaction recorded"
                : string.Format(CultureInfo.CurrentCulture, "{0} transactions recorded", summary.TransactionCount);

            cardIncome.Value = summary.TotalIncome.ToString("C");
            cardIncome.Support = "Money received";

            cardExpense.Value = summary.TotalExpense.ToString("C");
            cardExpense.Support = "Money spent";

            cardSavings.Value = string.Format(CultureInfo.CurrentCulture, "{0:0.#}%", summary.SavingsProgressPercentage);
            cardSavings.Support = summary.ActiveGoalCount + summary.CompletedGoalCount == 0
                ? "No goals set yet"
                : string.Format(
                    CultureInfo.CurrentCulture,
                    "{0} of {1} across {2} goal{3}",
                    summary.SavingsSavedTotal.ToString("C", CultureInfo.CurrentCulture),
                    summary.SavingsTargetTotal.ToString("C", CultureInfo.CurrentCulture),
                    summary.ActiveGoalCount + summary.CompletedGoalCount,
                    summary.ActiveGoalCount + summary.CompletedGoalCount == 1 ? string.Empty : "s");
        }

        private void LoadChart()
        {
            List<ReportMonthlySummaryDto> months;
            try
            {
                months = _reportsController.GetMonthlySummaryReport();
            }
            catch
            {
                months = new List<ReportMonthlySummaryDto>();
            }

            var active = months
                .Where(m => m.TotalIncome > 0m || m.TotalExpense > 0m)
                .OrderBy(m => m.Month)
                .ToList();

            if (active.Count > 6)
                active = active.Skip(active.Count - 6).ToList();

            var bars = new List<ChartBar>();
            foreach (var month in active)
            {
                string label = new DateTime(month.Year, month.Month, 1).ToString("MMM", CultureInfo.CurrentCulture);
                bars.Add(new ChartBar(label, month.TotalIncome, month.TotalExpense));
            }

            chart.SetData(bars);
        }

        private void LoadRecent()
        {
            List<TransactionResponseDto> recent;
            try
            {
                recent = _controller.GetRecentTransactions(6);
            }
            catch
            {
                recent = new List<TransactionResponseDto>();
            }

            recentList.SuspendLayout();

            // Disposing takes each row out of the panel; a bare Clear would
            // leave the previous rows alive for the rest of the session.
            while (recentList.Controls.Count > 0)
                recentList.Controls[0].Dispose();

            foreach (var item in recent)
            {
                recentList.Controls.Add(new TransactionRow
                {
                    Item = item,
                    Width = FlowList.RowWidth(recentList)
                });
            }
            recentList.ResumeLayout();

            // Re-fitted once the scrollbar state has settled, so a list long
            // enough to scroll never drags a horizontal scrollbar with it.
            FlowList.FitRows(recentList);

            bool hasItems = recent.Count > 0;
            recentList.Visible = hasItems;
            recentEmpty.Visible = !hasItems;
        }

        private void LoadGoals()
        {
            List<SavingGoalResponseDto> goals;
            try
            {
                goals = _savingGoalController.GetAllSavingGoals();
            }
            catch
            {
                goals = new List<SavingGoalResponseDto>();
            }

            // Only the goals that are still being funded earn a bar; a finished
            // goal is in the list already and saying so twice is noise.
            var funded = goals
                .Where(g => g.Status != Domains.SavingGoalStatus.ARCHIVED && g.Status != Domains.SavingGoalStatus.COMPLETED)
                .OrderByDescending(g => g.ProgressPercentage)
                .ToList();

            goalList.SuspendLayout();

            // Disposing takes each row out of the panel.
            while (goalList.Controls.Count > 0)
                goalList.Controls[0].Dispose();

            foreach (var goal in funded)
            {
                var row = new GoalProgressRow
                {
                    Width = FlowList.RowWidth(goalList),
                    Height = 34
                };
                row.Bind(goal);
                goalList.Controls.Add(row);
            }
            goalList.ResumeLayout();

            FlowList.FitRows(goalList);

            bool hasItems = goals.Count > 0;
            goalList.Visible = hasItems;
            goalEmpty.Visible = !hasItems;
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            // Load fires once per instance, so this is only the first show.
            // Every later visit goes through MainForm -> RefreshData.
            RefreshData();
        }
    }
}
