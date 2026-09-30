namespace PersonalExpenseTracker.Domains
{
    /// <summary>
    /// Lifecycle of a saving goal. Derived rather than stored, so a goal can
    /// never claim to be in progress after it has been fully funded.
    /// </summary>
    public enum SavingGoalStatus
    {
        IN_PROGRESS,
        COMPLETED,
        OVERDUE,
        ARCHIVED
    }
}
