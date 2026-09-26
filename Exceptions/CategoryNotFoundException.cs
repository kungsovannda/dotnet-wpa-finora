using System;

namespace PersonalExpenseTracker.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(long id) 
            : base($"Category with ID {id} not found.")
        {
        }
    }
}
