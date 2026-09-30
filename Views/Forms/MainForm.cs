using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Views.Data;
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
        private readonly SavingGoalControl _savingGoal;
        private readonly ReportControl _report;

        private UserControl? _current;

        public MainForm(
            DashboardControl dashboard,
            SettingControl setting,
            CategoryControl category,
            TransactionControl transaction,
            SavingGoalControl savingGoal,
            ReportControl report,
            CurrentUserSession session)
        {
            _dashboard = dashboard;
            _setting = setting;
            _category = category;
            _transaction = transaction;
            _savingGoal = savingGoal;
            _report = report;
            InitializeComponent();
            Typography.Apply(this);
            sidebar.NavigationRequested += Sidebar_NavigationRequested;
            _setting.LogoutRequested += Setting_LogoutRequested;

            if (session.IsSignedIn)
                header1.UserName = session.Username;

            ShowPage(_dashboard, reload: false);
        }

        private void ShowPage(UserControl page, bool reload = true)
        {
            bool alreadyShowing = ReferenceEquals(_current, page) && ReferenceEquals(page.Parent, panel);

            _current = page;

            panel.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panel.Controls.Add(page);

            if (reload && !alreadyShowing && page is IRefreshablePage refreshable)
                refreshable.RefreshData();
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

                case NavigationItem.SavingGoal:
                    ShowPage(_savingGoal);
                    break;

                case NavigationItem.Report:
                    ShowPage(_report);
                    break;

                case NavigationItem.Setting:
                    ShowPage(_setting);
                    break;
            }
        }

        /// <summary>
        /// The settings page has already cleared the session by the time this
        /// fires; all that is left is to end the run.
        /// </summary>
        private void Setting_LogoutRequested(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
