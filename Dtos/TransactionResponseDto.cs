using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class TransactionResponseDto
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; } = string.Empty;

        public PaymentMethod PaymentMethod { get; set; }

        public string Reference { get; set; } = string.Empty;

        public string Merchant { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
