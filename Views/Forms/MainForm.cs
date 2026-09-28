using PersonalExpenseTracker.Views.Navigations;
using PersonalExpenseTracker.Views.UI;
namespace PersonalExpenseTracker.Views.Forms
{
    public partial class MainForm : Form
    {
        private readonly DashboardControl _dashboard;
        private readonly SettingControl _setting;
        private readonly CategoryControl _category;

        private readonly TransactionControl _transaction;

        public MainForm(DashboardControl dashboard, SettingControl setting, CategoryControl category, TransactionControl transaction)
        {
            _dashboard = dashboard;
            _setting = setting;
            _category = category;
            _transaction = transaction;
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

                case NavigationItem.Category:
                    ShowPage(_category);
                    break;

                case NavigationItem.Transaction:
                    ShowPage(_transaction);
                    break;

                case NavigationItem.Setting:
                    ShowPage(_setting);
                    break;
            }
        }

    }
}
