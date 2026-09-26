using System;
using System.Collections.Generic;

namespace PersonalExpenseTracker.Dtos
{
    public class ReportMonthlySummaryDto
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal NetAmount { get; set; }
    }
}
