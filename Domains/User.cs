using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenseTracker.Domains
{
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public List<SavingGoal> SavingGoals { get; set; } = new List<SavingGoal>();
    }
}
