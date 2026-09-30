using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class CreateCategoryDto
    {
        public required string Name { get; set; }

        /// <summary>Optional. A blank description is stored as an empty string.</summary>
        public string? Description { get; set; }

        public TransactionType Type { get; set; }

        /// <summary>Optional emoji shown on the category.</summary>
        public string? Emoji { get; set; }
    }
}
