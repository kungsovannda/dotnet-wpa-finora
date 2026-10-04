using System;

namespace PersonalExpenseTracker.Domains
{
    /// <summary>
    /// A single deposit into a saving goal.
    /// <para>
    /// Deliberately not a <see cref="Transaction"/>: moving money you already
    /// own into a goal is not income and not an expense, so counting it as
    /// either would corrupt the dashboard balance and the reports. The
    /// contribution rows are the audit trail; the goal's saved total is written
    /// in the same transaction and always agrees with them.
    /// </para>
    /// </summary>
    public class SavingGoalContribution
    {
        public long Id { get; set; }

        public long SavingGoalId { get; set; }

        /// <summary>Inverse side of the relationship; loaded when a goal is read with its ledger.</summary>
        public SavingGoal? SavingGoal { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Note { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
