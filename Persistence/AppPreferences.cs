using System;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace PersonalExpenseTracker.Persistence
{
    /// <summary>
    /// The few things the user can configure about the app itself: how money
    /// and dates are formatted. Kept as a plain object so it serialises
    /// straight to JSON.
    /// </summary>
    public class AppPreferences
    {
        /// <summary>
        /// Culture name used for amounts and dates, or <c>null</c> for whatever
        /// the OS is set to.
        /// </summary>
        public string? CultureName { get; set; }
    }

    /// <summary>
    /// Reads and writes <see cref="AppPreferences"/> from a small JSON file
    /// next to the database. Loaded once at startup and written on every
    /// change - there is no Save button: what the settings page shows is what
    /// the app is already using.
    /// </summary>
    public sealed class AppPreferencesStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        /// <summary>
        /// The OS culture, captured before anything is overridden, so choosing
        /// "System default" again really does go back to it.
        /// </summary>
        private static readonly CultureInfo SystemCulture = CultureInfo.CurrentCulture;

        private readonly string _path;

        public AppPreferencesStore()
            : this(Path.Combine(AppContext.BaseDirectory, "finora.settings.json"))
        {
        }

        public AppPreferencesStore(string path)
        {
            _path = path;
            Current = Load();
            ApplyCulture();
        }

        /// <summary>The values currently in effect.</summary>
        public AppPreferences Current { get; }

        /// <summary>Where the preferences are persisted.</summary>
        public string FilePath => _path;

        /// <summary>Switches the app-wide number and date format.</summary>
        public void SetCulture(string? cultureName)
        {
            Current.CultureName = cultureName;
            ApplyCulture();
            Save();
        }

        private AppPreferences Load()
        {
            try
            {
                if (File.Exists(_path))
                {
                    return JsonSerializer.Deserialize<AppPreferences>(File.ReadAllText(_path))
                           ?? new AppPreferences();
                }
            }
            catch
            {
                // A corrupt or unreadable file must never stop the app from
                // starting - fall back to the defaults.
            }

            return new AppPreferences();
        }

        private void Save()
        {
            try
            {
                File.WriteAllText(_path, JsonSerializer.Serialize(Current, JsonOptions));
            }
            catch
            {
                // Preferences are a convenience; failing to write one is not
                // worth interrupting the user for.
            }
        }

        /// <summary>
        /// Puts the chosen culture on this thread and on every thread the app
        /// starts afterwards, so every amount and date is formatted the same
        /// way without touching each call site.
        /// </summary>
        private void ApplyCulture()
        {
            CultureInfo culture = SystemCulture;

            if (!string.IsNullOrWhiteSpace(Current.CultureName))
            {
                try
                {
                    culture = CultureInfo.GetCultureInfo(Current.CultureName);
                }
                catch (CultureNotFoundException)
                {
                    // Unknown name in the file: keep the system default.
                }
            }

            // Only the culture is moved, never the UI culture: this setting is
            // about how numbers and dates read, not about the language of the
            // app (or of the system dialogs it raises).
            CultureInfo.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
        }
    }
    public sealed class CultureOption
    {
        public CultureOption(string displayName, string? cultureName, string currencySymbol)
        {
            DisplayName = displayName;
            CultureName = cultureName;
            CurrencySymbol = currencySymbol;
        }

        public string DisplayName { get; }
        public string? CultureName { get; }
        public string CurrencySymbol { get; }
    }
}