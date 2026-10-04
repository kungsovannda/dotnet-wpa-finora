namespace PersonalExpenseTracker.Exceptions
{
    public class SavingGoalNotFoundException : Exception
    {
        public SavingGoalNotFoundException(long id)
            : base($"Saving goal with ID {id} not found.")
        {
        }
    }
}
