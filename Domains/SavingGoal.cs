using System;
using System.Collections.Generic;

namespace PersonalExpenseTracker.Domains
{
    /// <summary>
    /// A destination the user is saving towards.
    /// <para>
    /// The saved total is a stored column rather than a running counter kept by
    /// the UI: it is only ever written by the service, in the same
    /// <c>SaveChanges</c> that writes the matching contribution row, so the two
    /// cannot drift apart.
    /// </para>
    /// </summary>
    public class SavingGoal
    {
        public long Id { get; set; }

        public long? UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        /// <summary>Emoji shown on the goal card, matching the category treatment.</summary>
        public string Emoji { get; set; } = string.Empty;

        public decimal TargetAmount { get; set; }

        public decimal CurrentAmount { get; set; }

        /// <summary>Optional. A goal without a deadline is never overdue.</summary>
        public DateTime? TargetDate { get; set; }

        /// <summary>Set by the user to retire a goal without deleting its history.</summary>
        public bool IsArchived { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public List<SavingGoalContribution> Contributions { get; set; } = new List<SavingGoalContribution>();

        /// <summary>
        /// Derived state, so a goal cannot stay "in progress" once it is funded
        /// and a missed deadline surfaces without anyone updating a column.
        /// </summary>
        public SavingGoalStatus Status
        {
            get
            {
                if (IsArchived)
                    return SavingGoalStatus.ARCHIVED;

                if (TargetAmount > 0m && CurrentAmount >= TargetAmount)
                    return SavingGoalStatus.COMPLETED;

                if (TargetDate.HasValue && TargetDate.Value.Date < DateTime.Today)
                    return SavingGoalStatus.OVERDUE;

                return SavingGoalStatus.IN_PROGRESS;
            }
        }

        /// <summary>Clamped so a zero target cannot divide by zero and an overshot goal cannot exceed 100.</summary>
        public decimal ProgressPercentage
        {
            get
            {
                if (TargetAmount <= 0m)
                    return 0m;

                return Math.Min(100m, Math.Round(CurrentAmount / TargetAmount * 100m, 2));
            }
        }

        /// <summary>Never negative: an overshot goal reads as complete, not as a debt.</summary>
        public decimal RemainingAmount => Math.Max(0m, TargetAmount - CurrentAmount);
    }
}
