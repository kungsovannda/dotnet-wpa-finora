using System;

namespace PersonalExpenseTracker.Exceptions
{
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException(long id) 
            : base($"Transaction with ID {id} not found.")
        {
        }
    }
}
