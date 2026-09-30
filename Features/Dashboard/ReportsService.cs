using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Dashboard
{
    public interface ReportsService
    {
        ReportIncomeVsExpenseDto GetIncomeVsExpenseReport();

        ReportIncomeVsExpenseDto GetIncomeVsExpenseReport(DateTime from, DateTime to);

        List<ReportCategoryExpenseDto> GetExpenseByCategoryReport();

        List<ReportCategoryExpenseDto> GetExpenseByCategoryReport(DateTime from, DateTime to);

        List<ReportMonthlySummaryDto> GetMonthlySummaryReport();

        List<ReportMonthlySummaryDto> GetMonthlySummaryReport(int year);

        List<ReportPaymentMethodDto> GetPaymentMethodReport();

        List<ReportPaymentMethodDto> GetPaymentMethodReport(DateTime from, DateTime to);

        /// <summary>Goal count, totals and overall progress across every saving goal.</summary>
        SavingGoalOverviewDto GetSavingGoalOverview();
    }
}
