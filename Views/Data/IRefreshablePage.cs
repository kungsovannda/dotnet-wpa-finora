namespace PersonalExpenseTracker.Views.Data
{
    /// <summary>
    /// A page that knows how to re-query its own data.
    /// <para>
    /// MainForm calls <see cref="RefreshData"/> every time a page is navigated
    /// to. Implementing this is how a page opts into that, and it keeps the
    /// "load" logic in one place instead of spread across Load/VisibleChanged
    /// and every mutation handler.
    /// </para>
    /// </summary>
    public interface IRefreshablePage
    {
        /// <summary>
        /// Re-reads this page's data from its controller and re-renders. Must be
        /// safe to call repeatedly, and must not raise
        /// <see cref="DataChangeNotifier.Changed"/> - refreshing is a read.
        /// </para>
        void RefreshData();
    }
}
