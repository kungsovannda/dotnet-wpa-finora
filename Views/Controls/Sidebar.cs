using PersonalExpenseTracker.Views.Navigations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Controls
{
    public partial class Sidebar : UserControl
    {
        public event EventHandler<NavigationEventArgs>? NavigationRequested;
        public Sidebar()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Dashboard));
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Setting));
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            NavigationRequested?.Invoke(this, new NavigationEventArgs(NavigationItem.Category));
        }
    }
}
