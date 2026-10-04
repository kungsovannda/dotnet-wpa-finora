using System;
using System.Collections.Generic;

namespace PersonalExpenseTracker.Domains
{
    public class Transaction
    {
        public long Id { get; set; }

        /// <summary>Owning account. Null only for rows created before sign-in.</summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Foreign key to the category. Canonical identity - the navigation
        /// property below is only loaded for display and mapping.
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>Loaded for display and mapping; the id above is the identity.</summary>
        public Category? Category { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; } = string.Empty;

        /// <summary>How the money moved. Defaults to cash for older records.</summary>
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CASH;

        /// <summary>Bank or merchant reference, when the user has one to hand.</summary>
        public string Reference { get; set; } = string.Empty;

        /// <summary>Where it happened: a shop, a payee, a city.</summary>
        public string Merchant { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public Transaction() { }

        public Transaction(long id, Category category, TransactionType type, decimal amount, DateTime date, string description)
        {
            Id = id;
            Category = category;
            Type = type;
            Amount = amount;
            Date = date;
            Description = description;
        }
    }
}
