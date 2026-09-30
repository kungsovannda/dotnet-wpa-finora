using System;

namespace PersonalExpenseTracker.Dtos
{
    public class AddGoalContributionDto
    {
        public long SavingGoalId { get; set; }

        public decimal Amount { get; set; }

        public DateTime? Date { get; set; }

        /// <summary>Optional. Blank is stored as an empty string.</summary>
        public string? Note { get; set; }
    }
}
