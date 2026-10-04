using System;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Exceptions;
using PersonalExpenseTracker.Utils;

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

            if (!Verify(user, password))
            {
                throw new AuthenticationException("Invalid username or password.");
            }

            return user;
        }


        private bool Verify(User user, string password)
        {
            if (PasswordHasher.IsEncoded(user.Password))
                return PasswordHasher.Verify(password, user.Password);

            if (!string.Equals(user.Password, password, StringComparison.Ordinal))
                return false;

            user.Password = PasswordHasher.Hash(password);
            _userRepository.Update(user);
            return true;
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
                Password = PasswordHasher.Hash(password),
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

        public void ChangePassword(string username, string currentPassword, string newPassword)
        {
            ValidateLoginInput(username, currentPassword);

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                throw new ValidationException("New password must be at least 6 characters long.");
            }

            var user = _userRepository.FindByUsername(username);
            if (user == null)
            {
                throw new AuthenticationException("Invalid username or password.");
            }

            if (!Verify(user, currentPassword))
            {
                throw new AuthenticationException("Current password is incorrect.");
            }

            // Comparing the stored value is not enough: the current password and
            // the new one may hash differently by chance, so the new one is checked
            // against the plain text it was derived from.
            if (string.Equals(currentPassword, newPassword, StringComparison.Ordinal))
            {
                throw new ValidationException("New password must be different from the current password.");
            }

            user.Password = PasswordHasher.Hash(newPassword);
            _userRepository.Update(user);
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

            if (!string.IsNullOrWhiteSpace(firstName) && firstName.Length > 50)
            {
                throw new ValidationException("First name cannot exceed 50 characters.");
            }

            if (!string.IsNullOrWhiteSpace(lastName) && lastName.Length > 50)
            {
                throw new ValidationException("Last name cannot exceed 50 characters.");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (email.Length > 100)
                {
                    throw new ValidationException("Email cannot exceed 100 characters.");
                }

                if (!email.Contains("@"))
                {
                    throw new ValidationException("Email format is invalid.");
                }
            }
        }
    }
}
