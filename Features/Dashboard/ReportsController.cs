using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.SavingGoals;

namespace PersonalExpenseTracker.Features.Dashboard
{
    public class ReportsController
    {
        private readonly ReportsService _reportsService;
        private readonly SavingGoalService _savingGoalService;

        public ReportsController(ReportsService reportsService, SavingGoalService savingGoalService)
        {
            _reportsService = reportsService;
            _savingGoalService = savingGoalService;
        }

        public ReportIncomeVsExpenseDto GetIncomeVsExpenseReport()
        {
            return _reportsService.GetIncomeVsExpenseReport();
        }

        public ReportIncomeVsExpenseDto GetIncomeVsExpenseReport(DateTime from, DateTime to)
        {
            return _reportsService.GetIncomeVsExpenseReport(from, to);
        }

        public List<ReportCategoryExpenseDto> GetExpenseByCategoryReport()
        {
            return _reportsService.GetExpenseByCategoryReport();
        }

        public List<ReportCategoryExpenseDto> GetExpenseByCategoryReport(DateTime from, DateTime to)
        {
            return _reportsService.GetExpenseByCategoryReport(from, to);
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport()
        {
            return _reportsService.GetMonthlySummaryReport();
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport(int year)
        {
            return _reportsService.GetMonthlySummaryReport(year);
        }

        public List<ReportPaymentMethodDto> GetPaymentMethodReport()
        {
            return _reportsService.GetPaymentMethodReport();
        }

        public List<ReportPaymentMethodDto> GetPaymentMethodReport(DateTime from, DateTime to)
        {
            return _reportsService.GetPaymentMethodReport(from, to);
        }

        public SavingGoalOverviewDto GetSavingGoalOverview()
        {
            return _savingGoalService.GetOverview();
        }
    }
}
