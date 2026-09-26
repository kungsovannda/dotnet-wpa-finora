using System;
using System.Collections.Generic;

namespace PersonalExpenseTracker.Dtos
{
    public class ReportCategoryExpenseDto
    {
        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal TotalAmount { get; set; }

        public int Count { get; set; }
    }
}
