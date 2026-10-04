using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.SavingGoals;
using PersonalExpenseTracker.Utils;

namespace PersonalExpenseTracker.Features.Dashboard.Impls
{
    public class ReportsServiceImpl : ReportsService
    {
        private readonly Features.Transactions.TransactionRepository _transactionRepository;
        private readonly SavingGoalService _savingGoalService;

        public ReportsServiceImpl(
            Features.Transactions.TransactionRepository transactionRepository,
            SavingGoalService savingGoalService)
        {
            _transactionRepository = transactionRepository;
            _savingGoalService = savingGoalService;
        }

        public ReportIncomeVsExpenseDto GetIncomeVsExpenseReport()
        {
            return GetIncomeVsExpenseReport(null, null);
        }

        public ReportIncomeVsExpenseDto GetIncomeVsExpenseReport(DateTime from, DateTime to)
        {
            return GetIncomeVsExpenseReport((DateTime?)from, to);
        }

        private ReportIncomeVsExpenseDto GetIncomeVsExpenseReport(DateTime? from, DateTime? to)
        {
            var totalIncome = _transactionRepository.SumAmount(TransactionType.INCOME, from, to);
            var totalExpense = _transactionRepository.SumAmount(TransactionType.EXPENSE, from, to);

            return new ReportIncomeVsExpenseDto
            {
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                NetBalance = totalIncome - totalExpense
            };
        }

        public List<ReportCategoryExpenseDto> GetExpenseByCategoryReport()
        {
            return GetExpenseByCategoryReport(null, null);
        }

        public List<ReportCategoryExpenseDto> GetExpenseByCategoryReport(DateTime from, DateTime to)
        {
            return GetExpenseByCategoryReport((DateTime?)from, to);
        }

        private List<ReportCategoryExpenseDto> GetExpenseByCategoryReport(DateTime? from, DateTime? to)
        {
            return _transactionRepository.SumExpensesByCategory(from, to)
                .Select(m => new ReportCategoryExpenseDto
                {
                    CategoryId = m.KeyId,
                    CategoryName = m.Key,
                    TotalAmount = m.Total,
                    Count = m.Count
                })
                .ToList();
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport()
        {
            return GetMonthlySummaryReport(DateTime.Now.Year);
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport(int year)
        {
            var byMonth = _transactionRepository.SumByMonth(year)
                .ToDictionary(m => m.Month);

            var monthlySummaries = new List<ReportMonthlySummaryDto>();

            for (int month = 1; month <= 12; month++)
            {
                // Every month is listed, including the empty ones, so the
                // report shows a continuous twelve-month picture. A month with
                // no rows at all reads as zero rather than as a missing group.
                var totals = byMonth.TryGetValue(month, out var found) ? found : new Features.Transactions.MonthTotal();

                monthlySummaries.Add(new ReportMonthlySummaryDto
                {
                    Month = month,
                    Year = year,
                    TotalIncome = totals.TotalIncome,
                    TotalExpense = totals.TotalExpense,
                    NetAmount = totals.TotalIncome - totals.TotalExpense
                });
            }

            return monthlySummaries;
        }

        public List<ReportPaymentMethodDto> GetPaymentMethodReport()
        {
            return GetPaymentMethodReport(null, null);
        }

        public List<ReportPaymentMethodDto> GetPaymentMethodReport(DateTime from, DateTime to)
        {
            return GetPaymentMethodReport((DateTime?)from, to);
        }

        private List<ReportPaymentMethodDto> GetPaymentMethodReport(DateTime? from, DateTime? to)
        {
            return _transactionRepository.SumByPaymentMethod(from, to)
                .Select(m => new ReportPaymentMethodDto
                {
                    PaymentMethod = m.PaymentMethod,
                    Label = PaymentMethods.Label(m.PaymentMethod),
                    Total = m.Total,
                    Count = m.Count
                })
                .ToList();
        }

        public SavingGoalOverviewDto GetSavingGoalOverview()
        {
            return _savingGoalService.GetOverview();
        }
    }
}
