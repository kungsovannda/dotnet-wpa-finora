using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Authentication
{
    public class AuthenticationController
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public User Login(string username, string password)
        {
            return _authenticationService.Login(username, password);
        }

        public User Register(string username, string password, string firstName, string lastName, string email)
        {
            return _authenticationService.Register(username, password, firstName, lastName, email);
        }

        public bool ValidateCredentials(string username, string password)
        {
            return _authenticationService.ValidateCredentials(username, password);
        }

        public void ChangePassword(string username, string currentPassword, string newPassword)
        {
            _authenticationService.ChangePassword(username, currentPassword, newPassword);
        }
    }
}
