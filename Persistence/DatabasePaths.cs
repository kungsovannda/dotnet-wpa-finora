using System;
using System.IO;

namespace PersonalExpenseTracker.Persistence
{

    public static class DatabasePaths
    {
        private static string? overridePath;

        public static string DefaultConnectionStringPath
        {
            get => overridePath ?? Path.Combine(AppContext.BaseDirectory, "finora.db");
            set => overridePath = value;
        }
    }
}
