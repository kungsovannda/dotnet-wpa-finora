using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Mapper;

namespace PersonalExpenseTracker.Features.Dashboard.Impls
{
    public class DashboardServiceImpl : DashboardService
    {
        private readonly Features.Transactions.TransactionRepository _transactionRepository;

        public DashboardServiceImpl(Features.Transactions.TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public DashboardSummaryDto GetDashboardSummary()
        {
            var allTransactions = _transactionRepository.FindAll();

            var totalIncome = allTransactions
                .Where(t => t.Type == TransactionType.INCOME)
                .Sum(t => t.Amount);

            var totalExpense = allTransactions
                .Where(t => t.Type == TransactionType.EXPENSE)
                .Sum(t => t.Amount);

            var totalBalance = totalIncome - totalExpense;

            return new DashboardSummaryDto
            {
                TotalBalance = totalBalance,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                TransactionCount = allTransactions.Count
            };
        }

        public List<TransactionResponseDto> GetRecentTransactions(int limit = 10)
        {
            var allTransactions = _transactionRepository.FindAll();
            var recentTransactions = allTransactions
                .OrderByDescending(t => t.CreatedAt)
                .Take(limit)
                .ToList();

            return recentTransactions
                .Select(t => TransactionMapper.ToTransactionResponseDto(t))
                .ToList();
        }
    }
}
