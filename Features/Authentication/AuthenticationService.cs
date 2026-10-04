using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Authentication
{
    public interface AuthenticationService
    {
        User Login(string username, string password);

        User Register(string username, string password, string firstName, string lastName, string email);

        bool ValidateCredentials(string username, string password);

        /// <summary>Rotates the stored password after re-checking the current one.</summary>
        void ChangePassword(string username, string currentPassword, string newPassword);
    }
}
