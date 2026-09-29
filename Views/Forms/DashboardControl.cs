using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Dashboard;
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
    public partial class DashboardControl : UserControl
    {
        private readonly DashboardController _controller;
        private readonly ReportsController _reportsController;

        public DashboardControl(DashboardController controller, ReportsController reportsController)
        {
            InitializeComponent();
            _controller = controller;
            _reportsController = reportsController;
            recentList.ClientSizeChanged += (_, _) => ResizeRecentRows();
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
            LoadSummary();
            LoadChart();
            LoadRecent();
        }
    }
}
