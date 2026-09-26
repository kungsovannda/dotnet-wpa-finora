using System;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Exceptions;

namespace PersonalExpenseTracker.Features.Authentication.Impls
{
    public class AuthenticationServiceImpl : AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationServiceImpl(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string username, string password)
        {
            ValidateLoginInput(username, password);

            var user = _userRepository.FindByUsername(username);
            if (user == null)
            {
                throw new AuthenticationException("Invalid username or password.");
            }

            if (!user.Password.Equals(password))
            {
                throw new AuthenticationException("Invalid username or password.");
            }

            return user;
        }

        public User Register(string username, string password, string firstName, string lastName, string email)
        {
            ValidateRegistrationInput(username, password, firstName, lastName, email);

            if (_userRepository.ExistsByUsername(username))
            {
                throw new AuthenticationException($"Username '{username}' already exists.");
            }

            var newUser = new User
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            return _userRepository.Save(newUser);
        }

        public bool ValidateCredentials(string username, string password)
        {
            try
            {
                Login(username, password);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ValidateLoginInput(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ValidationException("Username cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ValidationException("Password cannot be null or empty.");
            }
        }

        private void ValidateRegistrationInput(string username, string password, string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            {
                throw new ValidationException("Username must be at least 3 characters long.");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                throw new ValidationException("Password must be at least 6 characters long.");
            }

            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 50)
            {
                throw new ValidationException("First name is required and cannot exceed 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 50)
            {
                throw new ValidationException("Last name is required and cannot exceed 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(email) || email.Length > 100)
            {
                throw new ValidationException("Email is required and cannot exceed 100 characters.");
            }

            if (!email.Contains("@"))
            {
                throw new ValidationException("Email format is invalid.");
            }
        }
    }
}
