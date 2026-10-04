using System;
using System.Security.Cryptography;
using System.Text;

namespace PersonalExpenseTracker.Utils
{
    /// <summary>
    /// One-way password storage for the <c>Users.Password</c> column.
    /// <para>
    /// A password is stored as a self-describing string -
    /// <c>pbkdf2-sha256$iterations$salt$hash</c>, base64url encoded - so the work
    /// factor lives in the data and can be raised later without invalidating
    /// existing accounts. Plaintext never leaves this class.
    /// </para>
    /// <para>
    /// Databases written before hashing existed still hold plaintext. Those rows
    /// are detected with <see cref="IsEncoded"/> and re-hashed on first
    /// successful sign-in, so upgrading costs the user nothing.
    /// </para>
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>Work factor for newly written hashes.</summary>
        public const int DefaultIterations = 120_000;

        private const string Prefix = "pbkdf2-sha256";
        private const int SaltBytes = 16;
        private const int HashBytes = 32;
        private const char Separator = '$';

        /// <summary>Derives a new salted hash for <paramref name="password"/>.</summary>
        public static string Hash(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            byte[] salt = RandomNumberGenerator.GetBytes(SaltBytes);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password), salt, DefaultIterations, HashAlgorithmName.SHA256, HashBytes);

            return string.Join(
                Separator.ToString(),
                Prefix,
                DefaultIterations.ToString(System.Globalization.CultureInfo.InvariantCulture),
                ToBase64Url(salt),
                ToBase64Url(hash));
        }

        /// <summary>
        /// Checks <paramref name="password"/> against an encoded hash. A value that
        /// is not encoded is treated as legacy plaintext, so pre-hashing accounts
        /// keep working.
        /// </summary>
        public static bool Verify(string password, string stored)
        {
            if (password == null || string.IsNullOrEmpty(stored))
                return false;

            if (!IsEncoded(stored))
                return string.Equals(stored, password, StringComparison.Ordinal);

            var parts = stored.Split(Separator);
            if (parts.Length != 4)
                return false;

            if (!int.TryParse(parts[1], System.Globalization.NumberStyles.Integer,
                    System.Globalization.CultureInfo.InvariantCulture, out int iterations) ||
                iterations <= 0)
                return false;

            byte[] salt;
            byte[] expected;
            try
            {
                salt = FromBase64Url(parts[2]);
                expected = FromBase64Url(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            if (expected.Length == 0)
                return false;

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password), salt, iterations, HashAlgorithmName.SHA256, expected.Length);

            // Fixed-time comparison: a byte-by-byte early exit would leak how much
            // of the hash matched.
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }

        /// <summary>True when the stored value is a hash rather than plaintext.</summary>
        public static bool IsEncoded(string? stored) =>
            !string.IsNullOrEmpty(stored) && stored!.StartsWith(Prefix + Separator, StringComparison.Ordinal);

        private static string ToBase64Url(byte[] value) =>
            Convert.ToBase64String(value).TrimEnd('=').Replace('+', '-').Replace('/', '_');

        private static byte[] FromBase64Url(string value)
        {
            string padded = value.Replace('-', '+').Replace('_', '/');
            switch (padded.Length % 4)
            {
                case 2: padded += "=="; break;
                case 3: padded += "="; break;
            }

            return Convert.FromBase64String(padded);
        }
    }
}
