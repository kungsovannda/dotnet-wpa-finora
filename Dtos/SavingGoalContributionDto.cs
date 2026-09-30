using System;

namespace PersonalExpenseTracker.Dtos
{
    public class SavingGoalContributionDto
    {
        public long Id { get; set; }

        public long SavingGoalId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
