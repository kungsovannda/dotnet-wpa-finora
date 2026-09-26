using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Authentication
{
    public interface AuthenticationService
    {
        User Login(string username, string password);

        User Register(string username, string password, string firstName, string lastName, string email);

        bool ValidateCredentials(string username, string password);
    }
}
