using System;

namespace PersonalExpenseTracker.Dtos
{
    public class ReportIncomeVsExpenseDto
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal NetBalance { get; set; }
    }
}
