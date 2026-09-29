using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TransactionType Type { get; set; }

        public string Emoji { get; set; }
    }
}
