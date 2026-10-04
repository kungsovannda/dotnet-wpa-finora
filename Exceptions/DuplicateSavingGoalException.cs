namespace PersonalExpenseTracker.Exceptions
{
    public class DuplicateSavingGoalException : Exception
    {
        public DuplicateSavingGoalException(string name)
            : base($"A saving goal with the name '{name}' already exists.")
        {
        }
    }
}
