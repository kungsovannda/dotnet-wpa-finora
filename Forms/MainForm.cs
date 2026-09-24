using PersonalExpenseTracker.Controls;
using PersonalExpenseTracker.Navigations;
using PersonalExpenseTracker.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime;
using System.Text;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Forms
{
    public partial class MainForm : Form
    {
        private readonly DashboardControl _dashboard = new();
        private readonly SettingControl _setting = new();
        public MainForm()
        {
            InitializeComponent();
            Typography.Apply(this);
            sidebar.NavigationRequested += Sidebar_NavigationRequested;
            ShowPage(_dashboard);
        }

        private void ShowPage(UserControl page)
        {
            panel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panel.Controls.Add(page);
        }

        private void Sidebar_NavigationRequested(object? sender, NavigationEventArgs e)
        {
            switch (e.Item)
            {
                case NavigationItem.Dashboard:
                    ShowPage(_dashboard);
                    break;

                case NavigationItem.Setting:
                    ShowPage(_setting);
                    break;
            }
        }

    }
}
