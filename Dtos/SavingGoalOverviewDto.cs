using System;

namespace PersonalExpenseTracker.Dtos
{
    /// <summary>Headline figures across every saving goal, for the dashboard and reports.</summary>
    public class SavingGoalOverviewDto
    {
        public int TotalGoals { get; set; }

        public int ActiveGoals { get; set; }

        public int CompletedGoals { get; set; }

        public int OverdueGoals { get; set; }

        public decimal TotalTargetAmount { get; set; }

        public decimal TotalSavedAmount { get; set; }

        /// <summary>Saved against target across all non-archived goals, 0 to 100.</summary>
        public decimal OverallProgressPercentage { get; set; }
    }
}
