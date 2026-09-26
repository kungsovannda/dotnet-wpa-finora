using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Dashboard
{
    public interface ReportsService
    {
        ReportIncomeVsExpenseDto GetIncomeVsExpenseReport();

        List<ReportCategoryExpenseDto> GetExpenseByCategoryReport();

        List<ReportMonthlySummaryDto> GetMonthlySummaryReport();

        List<ReportMonthlySummaryDto> GetMonthlySummaryReport(int year);
    }
}
