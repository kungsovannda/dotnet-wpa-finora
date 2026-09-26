using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class UpdateTransactionDto
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
