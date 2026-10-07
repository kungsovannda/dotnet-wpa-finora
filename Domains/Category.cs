using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenseTracker.Domains
{
    public class Category
    {
        public long Id { get; set; }

        /// <summary>Owning account, stamped on create and cleared with the user.</summary>
        public long? UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TransactionType Type { get; set; }

        /// <summary>Emoji shown on the category card (presentation value).</summary>
        public string Emoji { get; set; } = string.Empty;

        /// <summary>
        /// Soft-delete marker. Setting it hides the row from every read without
        /// removing the financial history that references it.
        /// </summary>
        public bool IsDeleted { get; set; }

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
