using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;

namespace PersonalExpenseTracker.Features.Dashboard.Impls
{
    public class ReportsServiceImpl : ReportsService
    {
        private readonly Features.Transactions.TransactionRepository _transactionRepository;

        public ReportsServiceImpl(Features.Transactions.TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public ReportIncomeVsExpenseDto GetIncomeVsExpenseReport()
        {
            var allTransactions = _transactionRepository.FindAll();

            var totalIncome = allTransactions
                .Where(t => t.Type == TransactionType.INCOME)
                .Sum(t => t.Amount);

            var totalExpense = allTransactions
                .Where(t => t.Type == TransactionType.EXPENSE)
                .Sum(t => t.Amount);

            return new ReportIncomeVsExpenseDto
            {
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                NetBalance = totalIncome - totalExpense
            };
        }

        public List<ReportCategoryExpenseDto> GetExpenseByCategoryReport()
        {
            var allTransactions = _transactionRepository.FindAll();

            var expensesByCategory = allTransactions
                .Where(t => t.Type == TransactionType.EXPENSE)
                .GroupBy(t => t.Category)
                .Select(g => new ReportCategoryExpenseDto
                {
                    CategoryId = g.Key.Id,
                    CategoryName = g.Key.Name,
                    TotalAmount = g.Sum(t => t.Amount),
                    Count = g.Count()
                })
                .OrderByDescending(r => r.TotalAmount)
                .ToList();

            return expensesByCategory;
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport()
        {
            return GetMonthlySummaryReport(DateTime.Now.Year);
        }

        public List<ReportMonthlySummaryDto> GetMonthlySummaryReport(int year)
        {
            var allTransactions = _transactionRepository.FindAll();

            var monthlySummaries = new List<ReportMonthlySummaryDto>();

            for (int month = 1; month <= 12; month++)
            {
                var monthTransactions = allTransactions
                    .Where(t => t.Date.Year == year && t.Date.Month == month)
                    .ToList();

                var totalIncome = monthTransactions
                    .Where(t => t.Type == TransactionType.INCOME)
                    .Sum(t => t.Amount);

                var totalExpense = monthTransactions
                    .Where(t => t.Type == TransactionType.EXPENSE)
                    .Sum(t => t.Amount);

                monthlySummaries.Add(new ReportMonthlySummaryDto
                {
                    Month = month,
                    Year = year,
                    TotalIncome = totalIncome,
                    TotalExpense = totalExpense,
                    NetAmount = totalIncome - totalExpense
                });
            }

            return monthlySummaries;
        }
    }
}
