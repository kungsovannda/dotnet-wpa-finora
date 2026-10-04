using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.Transactions;
using PersonalExpenseTracker.Mapper;

namespace PersonalExpenseTracker.Features.Dashboard.Impls
{
    public class DashboardServiceImpl : DashboardService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly Features.SavingGoals.SavingGoalService _savingGoalService;

        public DashboardServiceImpl(
            TransactionRepository transactionRepository,
            Features.SavingGoals.SavingGoalService savingGoalService)
        {
            _transactionRepository = transactionRepository;
            _savingGoalService = savingGoalService;
        }

        public DashboardSummaryDto GetDashboardSummary()
        {
            var totalIncome = _transactionRepository.SumAmount(TransactionType.INCOME);
            var totalExpense = _transactionRepository.SumAmount(TransactionType.EXPENSE);

            var monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var savings = _savingGoalService.GetOverview();

            return new DashboardSummaryDto
            {
                TotalBalance = totalIncome - totalExpense,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                TransactionCount = _transactionRepository.Count(),
                ThisMonthIncome = _transactionRepository.SumAmount(TransactionType.INCOME, monthStart, monthEnd),
                ThisMonthExpense = _transactionRepository.SumAmount(TransactionType.EXPENSE, monthStart, monthEnd),
                SavingsTargetTotal = savings.TotalTargetAmount,
                SavingsSavedTotal = savings.TotalSavedAmount,
                SavingsProgressPercentage = savings.OverallProgressPercentage,
                ActiveGoalCount = savings.ActiveGoals,
                CompletedGoalCount = savings.CompletedGoals
            };
        }

        public List<TransactionResponseDto> GetRecentTransactions(int limit = 10)
        {
            // Newest by when the money moved, not by when the row was written:
            // a back-dated entry added today belongs further down the list.
            // The id breaks ties so two same-day rows do not swap places.
            return _transactionRepository.Find(new TransactionFilter { Sort = TransactionSort.NewestFirst })
                .OrderByDescending(t => t.Date)
                .ThenByDescending(t => t.Id)
                .Take(limit)
                .Select(TransactionMapper.ToTransactionResponseDto)
                .ToList();
        }

        public SavingGoalOverviewDto GetSavingsOverview()
        {
            return _savingGoalService.GetOverview();
        }
    }
}
