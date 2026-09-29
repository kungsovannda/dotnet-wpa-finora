using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenseTracker.Domains
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TransactionType Type { get; set; }

        /// <summary>Emoji shown on the category card (presentation value).</summary>
        public string Emoji { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Category() { 

        }

        public Category(long id, string name, string description, TransactionType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }
    }
}
