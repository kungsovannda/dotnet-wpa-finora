using System;
using System.Collections.Generic;
using System.Linq;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Authentication.Impls
{
    public class UserRepositoryImpl : UserRepository
    {
        private static List<User> users = new List<User>();
        private static long nextId = 1;

        public User Save(User user)
        {
            user.Id = nextId++;
            users.Add(user);
            return user;
        }

        public User FindById(long id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User FindByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public List<User> FindAll()
        {
            return new List<User>(users);
        }

        public User Update(User user)
        {
            var existingUser = FindById(user.Id);
            if (existingUser == null)
                return null;

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            return existingUser;
        }

        public void Delete(long id)
        {
            var user = FindById(id);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public bool ExistsByUsername(string username)
        {
            return users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
