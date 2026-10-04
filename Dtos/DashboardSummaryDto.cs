using System;

namespace PersonalExpenseTracker.Dtos
{
    public class DashboardSummaryDto
    {
        public decimal TotalBalance { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public int TransactionCount { get; set; }

        public decimal ThisMonthIncome { get; set; }

        public decimal ThisMonthExpense { get; set; }

        public decimal ThisMonthNet => ThisMonthIncome - ThisMonthExpense;

        public decimal SavingsTargetTotal { get; set; }

        public decimal SavingsSavedTotal { get; set; }

        public decimal SavingsProgressPercentage { get; set; }

        public int ActiveGoalCount { get; set; }

        public int CompletedGoalCount { get; set; }
    }
}
