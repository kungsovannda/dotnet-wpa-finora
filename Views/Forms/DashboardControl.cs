using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Dashboard;
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
        private readonly DataChangeNotifier _changes;

        /// <summary>Guards against a refresh that somehow triggers another one.</summary>
        private bool _refreshing;

        public DashboardControl(
            DashboardController controller,
            ReportsController reportsController,
            DataChangeNotifier changes)
        {
            InitializeComponent();
            _controller = controller;
            _reportsController = reportsController;
            _changes = changes;
            recentList.ClientSizeChanged += (_, _) => ResizeRecentRows();

            // The dashboard renders transactions, their categories and the
            // monthly report, so any write can invalidate it. When it is not the
            // page on screen it simply does not repaint; MainForm re-queries it
            // on arrival instead.
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

            // Category renames show up in the recent-transaction rows too.
            if (!e.Includes(DataChange.Transactions) && !e.Includes(DataChange.Categories))
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

            cardTransaction.Value = summary.TransactionCount.ToString(CultureInfo.CurrentCulture);
            cardTransaction.Support = "Activity entries";
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
            recentList.Controls.Clear();
            foreach (var item in recent)
            {
                recentList.Controls.Add(new TransactionRow
                {
                    Item = item,
                    Width = Math.Max(80, recentList.ClientSize.Width - 4)
                });
            }
            recentList.ResumeLayout();

            bool hasItems = recent.Count > 0;
            recentList.Visible = hasItems;
            recentEmpty.Visible = !hasItems;
        }

        private void ResizeRecentRows()
        {
            int width = Math.Max(80, recentList.ClientSize.Width - 4);
            foreach (Control child in recentList.Controls)
            {
                if (child.Width != width)
                    child.Width = width;
            }
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            // Load fires once per instance, so this is only the first show.
            // Every later visit goes through MainForm -> RefreshData.
            RefreshData();
        }
    }
}
