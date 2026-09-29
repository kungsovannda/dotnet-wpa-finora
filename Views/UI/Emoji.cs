using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.UI
{
    /// <summary>One selectable emoji entry in the picker.</summary>
    public sealed class EmojiEntry
    {
        public EmojiEntry(string group, string glyph)
        {
            Group = group;
            Glyph = glyph;
        }

        public string Group { get; }

        public string Glyph { get; }
    }

    /// <summary>
    /// Lightweight emoji support for categories: a small curated library, input
    /// normalisation and the emoji font family. Glyphs are rasterised and cached
    /// by <see cref="EmojiRenderer"/>, which keeps them crisp and tintable.
    /// </summary>
    public static class Emoji
    {
        public const string Family = "Segoe UI Emoji";

        /// <summary>Fallback glyphs so a category card is never empty.</summary>
        public const string DefaultIncome = "\U0001F4B0";  // money bag
        public const string DefaultExpense = "\U0001F9FE"; // receipt
        public const string DefaultCategory = "\U0001F3F7"; // label tag

        private static readonly (string Group, string Glyphs)[] RawGroups =
        {
            ("Money", "\U0001F4B0\U0001F4B1\U0001F4B3\U0001F4B4\U0001F4B5\U0001F4B6\U0001F4B7\U0001F4B8\U0001F4B9\U0001FA99\U0001F4C8"),
            ("General", "\U0001F3F7\U0001F4C1\U0001F4C2\U0001F4C3\U0001F4C4\U0001F4CA\U0001F4C9\U0001F4CB\U0001F4CC\U0001F4CD\U0001F4CE\U0001F5D2\U0001F5D3"),
            ("Food", "\U0001F354\U0001F355\U0001F356\U0001F357\U0001F358\U0001F35A\U0001F35B\U0001F35C\U0001F35D\U0001F35E\U0001F35F\U0001F360\U0001F362\U0001F363\U0001F364\U0001F365\U0001F367\U0001F368\U0001F369\U0001F370\U0001F37F\U0001F95B" ),
            ("Shopping", "\U0001F6CD\U0001F392\U0001F45E\U0001F45F\U0001F45D\U0001F6D2\U0001F48E\U0001F494\U0001F495\U0001F496\U0001F453\U0001F6D5\U0001F6CF\U0001F9FE" ),
            ("Bills & Home", "\U0001F3E0\U0001F3E1\U0001F3E2\U0001F3E5\U0001F6E1\U0001F4A1\U0001F52E\U0001F4DC\U0001F4D8\U0001F4C7\U0001F4DD\U0001F916\U0001F6B2\U0001F6AB\U0001F512\U0001F6CE\U0001F9F4" ),
            ("Transport", "\U0001F697\U0001F68C\U0001F69D\U0001F684\U0001F685\U0001F686\U0001F687\U0001F68B\U0001F69C\U0001F6B5\U0001F6B6\U0001F6E5\U0001F6E9\U0001F68F\U0001F6F0" ),
            ("Health", "\U0001FA7A\U0001FA7C\U0001F9D1\U0001F48A\U0001F48B\U0001F48C\U0001F48E\U0001F490\U0001F957\U0001F9D8\U0001FA79\U0001F9FF" ),
            ("Work & Study", "\U0001F4BB\U0001F4BC\U0001F4DA\U0001F3A8\U0001F4D6\U0001F4D7\U0001F4BE\U0001F4BF\U0001F31F\U0001F4E3\U0001F9EE" ),
            ("Leisure", "\U0001F3AE\U0001F3B0\U0001F3B1\U0001F3AD\U0001F3B8\U0001F3B9\U0001F3A0\U0001F9E0\U0001F393\U0001F3B5\U0001F3BC\U0001F941" ),
            ("Travel", "\U00002757\U0001F30D\U0001F3D5\U0001F3D6\U00002728\U0001F6F6\U0001F3E1\U0001F5FC\U0001F9ED" ),
            ("Nature", "\U0001F33F\U0001F340\U0001F338\U0001F33B\U0001F343\U0001F344\U0001F347\U0001F348\U0001F349\U0001F352\U0001F353\U0001F33E\U00002615\U0001F30A" ),
            ("Symbols", "\u2764\uFE0F\u2B50\u26A1\u2728\u2705\u274C\u26A0\uFE0F\u2757\u2753\u21AF\u2192\u2190\u2191\u2193\u25CF\u25B6\uFE0F\u23F1\uFE0F" )
        };

        private static List<EmojiEntry>? _entries;

        /// <summary>Flat, ordered list of every selectable emoji.</summary>
        public static IReadOnlyList<EmojiEntry> Entries =>
            _entries ??= BuildEntries();

        public static IReadOnlyList<string> GroupNames
        {
            get
            {
                var names = new List<string>();
                foreach (var entry in Entries)
                {
                    if (!names.Contains(entry.Group))
                        names.Add(entry.Group);
                }
                return names;
            }
        }

        private static List<EmojiEntry> BuildEntries()
        {
            var list = new List<EmojiEntry>();
            var seen = new HashSet<string>(StringComparer.Ordinal);

            foreach (var group in RawGroups)
            {
                var enumerator = StringInfo.GetTextElementEnumerator(group.Glyphs);
                while (enumerator.MoveNext())
                {
                    var glyph = (string)enumerator.Current;
                    if (string.IsNullOrWhiteSpace(glyph))
                        continue;

                    if (seen.Add(glyph))
                        list.Add(new EmojiEntry(group.Group, glyph));
                }
            }

            return list;
        }

        /// <summary>
        /// Cleans up whatever the user typed into the emoji field: strips
        /// whitespace / control characters and keeps at most two grapheme
        /// clusters. Never throws, never rejects input.
        /// </summary>
        public static string Normalize(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return string.Empty;

            var trimmed = raw.Trim();
            var builder = new StringBuilder();
            int clusters = 0;

            var enumerator = StringInfo.GetTextElementEnumerator(trimmed);
            while (enumerator.MoveNext() && clusters < 2)
            {
                var cluster = (string)enumerator.Current;
                if (string.IsNullOrEmpty(cluster))
                    continue;

                bool onlyBlank = true;
                foreach (var ch in cluster)
                {
                    if (!char.IsWhiteSpace(ch) && !char.IsControl(ch))
                    {
                        onlyBlank = false;
                        break;
                    }
                }

                if (onlyBlank)
                    continue;

                builder.Append(cluster);
                clusters++;
            }

            return builder.ToString();
        }

        /// <summary>Glyph shown on a card when a category has no emoji.</summary>
        public static string Fallback(bool isIncome) =>
            string.IsNullOrEmpty(DefaultCategory) ? (isIncome ? DefaultIncome : DefaultExpense) : DefaultCategory;
    }
}
