using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Dashboard;
using PersonalExpenseTracker.Features.SavingGoals;
using PersonalExpenseTracker.Utils;
using PersonalExpenseTracker.Views.Data;
using PersonalExpenseTracker.Views.UI;
using PersonalExpenseTracker.Views.UI.Controls;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// The Reports page. One period selector drives every figure on the page, so
    /// the income headline, the category split, the payment methods and the
    /// monthly chart are always talking about the same slice of time. All the
    /// arithmetic happens in the services; this only arranges what they return.
    /// </summary>
    public partial class ReportControl : UserControl, IRefreshablePage
    {
        private readonly ReportsController _controller;
        private readonly SavingGoalController _savingGoalController;
        private readonly DataChangeNotifier _changes;

        private bool _refreshing;
        private bool _populatingPeriods;

        public ReportControl(
            ReportsController controller,
            SavingGoalController savingGoalController,
            DataChangeNotifier changes)
        {
            _controller = controller;
            _savingGoalController = savingGoalController;
            _changes = changes;
            InitializeComponent();
            BackColor = Colors.Background;

            // The lists size their rows from the visible width, and the visible
            // width changes whenever a scrollbar appears or disappears - so the
            // rows are re-fitted whenever the panel itself resizes.
            categoryList.ClientSizeChanged += (_, _) => FlowList.FitRows(categoryList);
            methodList.ClientSizeChanged += (_, _) => FlowList.FitRows(methodList);
            goalList.ClientSizeChanged += (_, _) => FlowList.FitRows(goalList);

            _changes.Changed += Changes_Changed;
            Disposed += ReportControl_Disposed;
        }

        private void ReportControl_Disposed(object? sender, EventArgs e)
        {
            _changes.Changed -= Changes_Changed;
        }

        private void Changes_Changed(object? sender, DataChangedEventArgs e)
        {
            if (IsDisposed || Disposing)
                return;

            // A report is a snapshot of the database, so any write to any of the
            // three areas makes it stale.
            if (e.Change == DataChange.None)
                return;

            if (Visible)
                RefreshData();
        }

        public void RefreshData()
        {
            if (_refreshing || IsDisposed || !IsHandleCreated)
                return;

            _refreshing = true;
            try
            {
                PopulatePeriods();
                LoadReports();
            }
            finally
            {
                _refreshing = false;
            }
        }

        private void ReportControl_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void PopulatePeriods()
        {
            if (cbPeriod.Items.Count > 0)
                return;

            _populatingPeriods = true;
            try
            {
                cbPeriod.Items.Add("All time");
                cbPeriod.Items.Add("This month");
                cbPeriod.Items.Add("Last month");
                cbPeriod.Items.Add("This year");
                cbPeriod.Items.Add("Last year");
                cbPeriod.SelectedIndex = 0;
            }
            finally
            {
                _populatingPeriods = false;
            }
        }

        private void cbPeriod_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_populatingPeriods)
                return;

            LoadReports();
        }

        /// <summary>
        /// Translates the selected option into the period every report is then
        /// asked for. A null bound means "no restriction", which is the
        /// repository's own convention.
        /// </summary>
        private (DateTime? From, DateTime? To) CurrentPeriod()
        {
            var today = DateTime.Today;

            switch (cbPeriod.SelectedIndex)
            {
                case 1:
                    return (new DateTime(today.Year, today.Month, 1), new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)));

                case 2:
                {
                    var previous = today.AddMonths(-1);
                    return (new DateTime(previous.Year, previous.Month, 1),
                            new DateTime(previous.Year, previous.Month, DateTime.DaysInMonth(previous.Year, previous.Month)));
                }

                case 3:
                    return (new DateTime(today.Year, 1, 1), new DateTime(today.Year, 12, 31));

                case 4:
                    return (new DateTime(today.Year - 1, 1, 1), new DateTime(today.Year - 1, 12, 31));

                default:
                    return (null, null);
            }
        }

        /// <summary>The year the monthly chart covers, or null when the page is not period bound.</summary>
        private int? CurrentYear()
        {
            var today = DateTime.Today;

            return cbPeriod.SelectedIndex switch
            {
                3 => today.Year,
                4 => today.Year - 1,
                _ => null
            };
        }

        private string PeriodCaption()
        {
            var (from, to) = CurrentPeriod();

            if (!from.HasValue || !to.HasValue)
                return "Everything recorded so far.";

            return string.Format(
                CultureInfo.CurrentCulture,
                "1 {0} – {1} {2}.",
                from.Value.ToString("d MMMM", CultureInfo.CurrentCulture),
                to.Value.Day,
                to.Value.ToString("MMMM yyyy", CultureInfo.CurrentCulture));
        }

        private void LoadReports()
        {
            try
            {
                var (from, to) = CurrentPeriod();
                heading1.description = PeriodCaption();

                LoadTotals(from, to);
                LoadCategoryReport(from, to);
                LoadPaymentMethodReport(from, to);
                LoadMonthlySummary();
                LoadGoalReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    IsHandleCreated ? this : null,
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTotals(DateTime? from, DateTime? to)
        {
            var totals = from.HasValue && to.HasValue
                ? _controller.GetIncomeVsExpenseReport(from.Value, to.Value)
                : _controller.GetIncomeVsExpenseReport();

            cardIncome.Value = totals.TotalIncome.ToString("C", CultureInfo.CurrentCulture);
            cardIncome.Support = "Money received";

            cardExpense.Value = totals.TotalExpense.ToString("C", CultureInfo.CurrentCulture);
            cardExpense.Support = "Money spent";

            cardNet.Value = totals.NetBalance.ToString("C", CultureInfo.CurrentCulture);
            cardNet.Support = totals.NetBalance < 0m
                ? "Spending exceeds income"
                : "Left over after spending";
            cardNet.Tone = totals.NetBalance < 0m
                ? Views.Controls.StatTone.Expense
                : Views.Controls.StatTone.Income;
        }

        private void LoadCategoryReport(DateTime? from, DateTime? to)
        {
            var rows = from.HasValue && to.HasValue
                ? _controller.GetExpenseByCategoryReport(from.Value, to.Value)
                : _controller.GetExpenseByCategoryReport();

            RenderBarRows(
                categoryList,
                categoryEmpty,
                rows.Count == 0,
                "No expenses in this period",
                "Expenses recorded in this period will be grouped here.",
                rows.Select(r => new BarRow(
                    string.IsNullOrWhiteSpace(r.CategoryName) ? "Uncategorised" : r.CategoryName,
                    r.TotalAmount,
                    r.Count == 1 ? "1 transaction" : $"{r.Count} transactions")).ToList());
        }

        private void LoadPaymentMethodReport(DateTime? from, DateTime? to)
        {
            var rows = from.HasValue && to.HasValue
                ? _controller.GetPaymentMethodReport(from.Value, to.Value)
                : _controller.GetPaymentMethodReport();

            RenderBarRows(
                methodList,
                methodEmpty,
                rows.Count == 0,
                "No transactions in this period",
                "How you paid will be totalled here once you record something.",
                rows.Select(r => new BarRow(
                    r.Label,
                    r.Total,
                    r.Count == 1 ? "1 transaction" : $"{r.Count} transactions")).ToList());
        }

        private void RenderBarRows(
            FlowLayoutPanel host,
            EmptyState empty,
            bool isEmpty,
            string emptyTitle,
            string emptyDescription,
            List<BarRow> rows)
        {
            host.SuspendLayout();

            // Disposing takes each row out of the panel.
            while (host.Controls.Count > 0)
                host.Controls[0].Dispose();

            if (isEmpty)
            {
                host.ResumeLayout();
                host.Visible = false;
                empty.Title = emptyTitle;
                empty.Description = emptyDescription;
                empty.Visible = true;
                return;
            }

            // Bars are drawn relative to the largest row, so the biggest figure
            // in the group always fills the width.
            decimal largest = rows.Max(r => r.Amount);
            int rowWidth = FlowList.RowWidth(host);

            foreach (var row in rows)
            {
                var bar = new ReportBarRow
                {
                    ItemName = row.Name,
                    AmountText = row.Amount.ToString("C", CultureInfo.CurrentCulture),
                    BarColor = Colors.PrimaryOrange,
                    Share = largest <= 0m ? 0m : row.Amount / largest * 100m,
                    Detail = row.Detail,
                    Width = rowWidth,
                    Height = 44
                };

                host.Controls.Add(bar);
            }

            host.ResumeLayout();

            host.Visible = true;
            empty.Visible = false;

            // Rows sized before the scrollbar settled are re-fitted now, so the
            // list never asks for a horizontal scrollbar it does not need.
            FlowList.FitRows(host);
        }

        private void LoadMonthlySummary()
        {
            int? year = CurrentYear();
            var months = year.HasValue
                ? _controller.GetMonthlySummaryReport(year.Value)
                : _controller.GetMonthlySummaryReport();

            bool anyActivity = months.Any(m => m.TotalIncome > 0m || m.TotalExpense > 0m);

            monthChart.Visible = anyActivity;
            monthEmpty.Visible = !anyActivity;

            if (!anyActivity)
                return;

            lbMonthTitle.Text = year.HasValue
                ? string.Format(CultureInfo.CurrentCulture, "Monthly Summary · {0}", year.Value)
                : string.Format(CultureInfo.CurrentCulture, "Monthly Summary · {0}", DateTime.Today.Year);

            var bars = new List<ChartBar>();
            foreach (var month in months)
            {
                bars.Add(new ChartBar(
                    CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month.Month),
                    month.TotalIncome,
                    month.TotalExpense));
            }

            monthChart.SetData(bars);
        }

        private void LoadGoalReport()
        {
            var overview = _savingGoalController.GetOverview();
            var goals = _savingGoalController.GetAllSavingGoals();
            goalList.SuspendLayout();

            while (goalList.Controls.Count > 0)
                goalList.Controls[0].Dispose();

            if (goals.Count == 0)
            {
                goalList.ResumeLayout();
                goalList.Visible = false;
                goalEmpty.Visible = true;
                return;
            }

            foreach (var goal in goals)
            {
                var row = new GoalProgressRow
                {
                    Width = FlowList.RowWidth(goalList),
                    Height = 36
                };

                row.Bind(goal);
                goalList.Controls.Add(row);
            }

            goalList.ResumeLayout();

            goalList.Visible = true;
            goalEmpty.Visible = false;

            FlowList.FitRows(goalList);

            // The card title carries the headline so the list below can stay
            // one line per goal.
            lbGoalTitle.Text = string.Format(
                CultureInfo.CurrentCulture,
                "Saving Goals · {0:0.#}% funded",
                overview.OverallProgressPercentage);
        }

        /// <summary>One report line, flattened for the shared renderer.</summary>
        private readonly struct BarRow
        {
            public BarRow(string name, decimal amount, string detail)
            {
                Name = name;
                Amount = amount;
                Detail = detail;
            }

            public string Name { get; }

            public decimal Amount { get; }

            public string Detail { get; }
        }
    }
}
