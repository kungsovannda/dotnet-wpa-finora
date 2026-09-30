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

        public required string Description { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CASH;

        /// <summary>Optional bank or merchant reference. Blank is stored as an empty string.</summary>
        public string? Reference { get; set; }

        /// <summary>Optional. Where it happened. Blank is stored as an empty string.</summary>
        public string? Merchant { get; set; }
    }
}
