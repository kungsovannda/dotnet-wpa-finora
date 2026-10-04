using PersonalExpenseTracker.Views.Navigations;
using PersonalExpenseTracker.Views.UI.Controls;
using System;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Controls
{
    public partial class Sidebar : UserControl
    {
        public event EventHandler<NavigationEventArgs>? NavigationRequested;

        private NavigationItem _currentPage = NavigationItem.Dashboard;

        public Sidebar()
        {
            InitializeComponent();
            UpdateActiveState(NavigationItem.Dashboard);
        }

        private void UpdateActiveState(NavigationItem item)
        {
            _currentPage = item;
            ResetAllButtons();

            // Set active state for the selected button
            NavItem activeButton = item switch
            {
                NavigationItem.Dashboard => btnDashboard,
                NavigationItem.Transaction => btnTransaction,
                NavigationItem.Category => btnCategory,
                NavigationItem.SavingGoal => btnSavingGoal,
                NavigationItem.Report => btnReport,
                NavigationItem.Setting => btnSetting,
                _ => btnDashboard
            };

            activeButton.Selected = true;
        }

        private void ResetAllButtons()
        {
            foreach (var btn in new[] { btnDashboard, btnTransaction, btnCategory, btnSavingGoal, btnReport, btnSetting })
            {
                btn.Selected = false;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UpdateActiveState(NavigationItem.Dashboard);
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Dashboard));
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            UpdateActiveState(NavigationItem.Setting);
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Setting));
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            UpdateActiveState(NavigationItem.Category);
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Category));
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            UpdateActiveState(NavigationItem.Transaction);
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Transaction));
        }

        private void btnSavingGoal_Click(object sender, EventArgs e)
        {
            UpdateActiveState(NavigationItem.SavingGoal);
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.SavingGoal));
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            UpdateActiveState(NavigationItem.Report);
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Report));
        }
    }
}
