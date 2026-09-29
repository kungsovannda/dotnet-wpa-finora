using System;

namespace PersonalExpenseTracker.Views.Data
{
    /// <summary>What a write touched, so a page can skip work it does not need.</summary>
    [Flags]
    public enum DataChange
    {
        None = 0,
        Transactions = 1,
        Categories = 2,
        All = Transactions | Categories
    }

    public sealed class DataChangedEventArgs : EventArgs
    {
        public DataChangedEventArgs(DataChange change) => Change = change;

        public DataChange Change { get; }

        /// <summary>True when this write affects the given area.</summary>
        public bool Includes(DataChange area) => (Change & area) != 0;
    }

    /// <summary>
    /// A one-way "something was written" signal shared by the pages.
    /// <para>
    /// This is deliberately not a cache and it holds no data. A page that
    /// receives the signal re-queries its own controller exactly as it does on
    /// arrival, so the controllers, services and repositories stay the single
    /// source of truth and none of them know this type exists.
    /// </para>
    /// <para>
    /// It exists because <c>Control.Load</c> fires only once per control
    /// instance. MainForm keeps one instance of each page and re-parents it on
    /// every navigation, so without an explicit signal a page has no way of
    /// knowing that what it painted an hour ago is out of date.
    /// </para>
    /// </summary>
    public sealed class DataChangeNotifier
    {
        public event EventHandler<DataChangedEventArgs>? Changed;

        /// <summary>Tells every listening page that <paramref name="change"/> was written.</summary>
        public void Notify(DataChange change)
        {
            Changed?.Invoke(this, new DataChangedEventArgs(change));
        }
    }
}
