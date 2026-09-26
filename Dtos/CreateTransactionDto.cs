using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class CreateTransactionDto
    {
        public long CategoryId { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; }
    }
}
