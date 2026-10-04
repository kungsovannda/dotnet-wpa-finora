namespace PersonalExpenseTracker.Features.Authentication
{
    /// <summary>
    /// The signed-in account, established by a successful login and cleared on
    /// logout. Registered as a singleton: it is session state, not a unit of work.
    /// <para>
    /// Repositories stamp it onto new rows and scope their reads to it once
    /// someone is signed in, which keeps ownership real without threading a user
    /// id through every existing service signature.
    /// </para>
    /// </summary>
    public class CurrentUserSession
    {
        public long? UserId { get; private set; }

        /// <summary>Empty while signed out, so a caller never has to null-check the name.</summary>
        public string Username { get; private set; } = string.Empty;

        public bool IsSignedIn => UserId.HasValue;

        public void SignIn(long userId, string username)
        {
            UserId = userId;
            Username = username;
        }

        public void SignOut()
        {
            UserId = null;
            Username = string.Empty;
        }
    }
}
