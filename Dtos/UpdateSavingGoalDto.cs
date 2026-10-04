using System;

namespace PersonalExpenseTracker.Dtos
{
    public class UpdateSavingGoalDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        /// <summary>Optional. A blank description is stored as an empty string.</summary>
        public string? Description { get; set; }

        /// <summary>Optional emoji shown on the goal card.</summary>
        public string? Emoji { get; set; }

        public decimal TargetAmount { get; set; }

        /// <summary>Optional. A goal without a deadline is never overdue.</summary>
        public DateTime? TargetDate { get; set; }

        public bool IsArchived { get; set; }
    }
}
