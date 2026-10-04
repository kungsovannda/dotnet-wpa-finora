using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class CategoryResponseDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TransactionType Type { get; set; }

        public string Emoji { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
