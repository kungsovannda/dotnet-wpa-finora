using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Persistence;

namespace PersonalExpenseTracker.Features.Authentication.Impls
{
    public class UserRepositoryImpl : UserRepository
    {
        private readonly FinoraDbContext _db;

        public UserRepositoryImpl(FinoraDbContext db)
        {
            _db = db;
        }

        public User Save(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User? FindById(long id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? FindByUsername(string username)
        {
            return _db.Users.FirstOrDefault(u => u.Username.ToLower() == (username ?? string.Empty).ToLower());
        }

        public List<User> FindAll()
        {
            return _db.Users.AsNoTracking().OrderBy(u => u.Id).ToList();
        }

        public User? Update(User user)
        {
            var existingUser = _db.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
                return null;

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            _db.SaveChanges();
            return existingUser;
        }

        public void Delete(long id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public bool ExistsByUsername(string username)
        {
            return _db.Users.Any(u => u.Username.ToLower() == (username ?? string.Empty).ToLower());
        }
    }
}
