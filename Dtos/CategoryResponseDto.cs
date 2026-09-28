using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class CategoryResponseDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TransactionType Type { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
