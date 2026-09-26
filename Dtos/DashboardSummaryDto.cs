using System;

namespace PersonalExpenseTracker.Dtos
{
    public class DashboardSummaryDto
    {
        public decimal TotalBalance { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public int TransactionCount { get; set; }
    }
}
