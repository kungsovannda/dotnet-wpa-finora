using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenseTracker.Domains
{
    public class Transaction
    {
        public long Id { get; set; }

        public Category Category { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

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
