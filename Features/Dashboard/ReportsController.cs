using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Dashboard
{
    public class ReportsController
    {
        private readonly ReportsService _reportsService;

        public ReportsController(ReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        public ReportIncomeVsExpenseDto GetIncomeVsExpenseReport()
        {
            return _reportsService.GetIncomeVsExpenseReport();
        }

        public List<ReportCategoryExpenseDto> GetExpenseByCategoryReport()
        {
            return _reportsService.GetExpenseByCategoryReport();
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport()
        {
            return _reportsService.GetMonthlySummaryReport();
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport(int year)
        {
            return _reportsService.GetMonthlySummaryReport(year);
        }
    }
}
