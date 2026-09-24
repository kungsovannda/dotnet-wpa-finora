namespace PersonalExpenseTracker.Views.Navigations
{
    public class NavigationEventArgs : EventArgs
    {
        public NavigationItem Item { get; }

        public NavigationEventArgs(NavigationItem item)
        {
            Item = item;
        }
    }
}
