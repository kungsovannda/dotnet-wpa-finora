using System;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Dtos
{
    public class SavingGoalResponseDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Emoji { get; set; } = string.Empty;

        public decimal TargetAmount { get; set; }

        public decimal CurrentAmount { get; set; }

        /// <summary>Never negative; an overshot goal reads as fully funded.</summary>
        public decimal RemainingAmount { get; set; }

        /// <summary>0 to 100, rounded to two places.</summary>
        public decimal ProgressPercentage { get; set; }

        public DateTime? TargetDate { get; set; }

        public bool IsArchived { get; set; }

        public SavingGoalStatus Status { get; set; }

        public int ContributionCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
