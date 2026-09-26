using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenseTracker.Domains
{
    public class User
    {
        public long Id { get; set; }

        public String Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}
