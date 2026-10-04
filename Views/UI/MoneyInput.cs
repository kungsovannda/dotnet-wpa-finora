using System;
using System.Globalization;
using PersonalExpenseTracker.Views.UI.Controls;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>
    /// Reading a money amount out of a text field, shared by every dialog that
    /// takes one. Kept in the view layer because it is about what a person can
    /// type, not about the rules - the service still owns the real validation.
    /// </summary>
    public static class MoneyInput
    {
        public const int MaxLength = 18;

        public const string Placeholder = "0.00";

        /// <summary>
        /// Parses a typed amount, returning zero for anything unusable. Zero is
        /// deliberately the failure value: it is the one figure every service
        /// rejects anyway, so bad input can never become a valid record.
        /// </summary>
        public static decimal Parse(string raw)
        {
            raw = (raw ?? string.Empty).Trim();

            if (raw.Length == 0)
                return 0m;

            bool parsed =
                decimal.TryParse(raw, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal amount) ||
                decimal.TryParse(raw, NumberStyles.Currency, CultureInfo.InvariantCulture, out amount);

            return parsed && amount > 0m ? amount : 0m;
        }

        /// <summary>
        /// Reads a field, accepting what a person would actually type for money -
        /// grouping separators, a currency symbol, either decimal separator - and
        /// mirroring the service rule that an amount must be above zero.
        /// </summary>
        public static bool TryRead(AppTextField field, string label, out decimal value, out string error)
        {
            value = 0m;
            error = string.Empty;

            string raw = (field.Text ?? string.Empty).Trim();

            if (raw.Length == 0)
            {
                error = $"Enter {label} before saving.";
                return false;
            }

            value = Parse(raw);

            if (value > 0m)
                return true;

            bool looksNumeric = decimal.TryParse(raw, NumberStyles.Currency, CultureInfo.CurrentCulture, out _);

            error = looksNumeric
                ? $"{label[0..1].ToUpperInvariant()}{label[1..]} must be greater than zero."
                : $"\"{raw}\" is not a valid {label.ToLowerInvariant()}.";

            return false;
        }
    }
}
