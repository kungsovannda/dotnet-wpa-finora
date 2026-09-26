using System;

namespace PersonalExpenseTracker.Exceptions
{
    public class DuplicateCategoryException : Exception
    {
        public DuplicateCategoryException(string categoryName) 
            : base($"A category with the name '{categoryName}' already exists.")
        {
        }
    }
}
