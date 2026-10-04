using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Authentication
{
    public interface UserRepository
    {
        User Save(User user);

        User? FindById(long id);

        User? FindByUsername(string username);

        List<User> FindAll();

        User? Update(User user);

        void Delete(long id);

        bool ExistsByUsername(string username);
    }
}
