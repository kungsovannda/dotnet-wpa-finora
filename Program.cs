using PersonalExpenseTracker.Views.Forms;
using Microsoft.Extensions.DependencyInjection;
using PersonalExpenseTracker.Features.Categories;
using PersonalExpenseTracker.Features.Categories.Impls;
using PersonalExpenseTracker.Features.Dashboard;
using PersonalExpenseTracker.Features.Dashboard.Impls;
using PersonalExpenseTracker.Features.Transactions;
using PersonalExpenseTracker.Features.Transactions.Impls;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Features.Authentication.Impls;


namespace PersonalExpenseTracker
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var services = new ServiceCollection();

            // Register Repository implementations
            services.AddSingleton<CategoryRepository, CategoryRepositoryImpl>();
            services.AddSingleton<TransactionRepository, TransactionRepositoryImpl>();
            services.AddSingleton<UserRepository, UserRepositoryImpl>();

            // Register Service implementations
            services.AddSingleton<CategoryService, CategoryServiceImpl>();
            services.AddSingleton<TransactionService, TransactionServiceImpl>();
            services.AddSingleton<AuthenticationService, AuthenticationServiceImpl>();
            services.AddSingleton<DashboardService, DashboardServiceImpl>();
            services.AddSingleton<ReportsService, ReportsServiceImpl>();

            // Register Controller implementations
            services.AddTransient<CategoryController>();
            services.AddTransient<TransactionController>();
            services.AddTransient<AuthenticationController>();
            services.AddTransient<DashboardController>();
            services.AddTransient<ReportsController>();

            // Register Forms
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<DashboardControl>();
            services.AddTransient<CategoryControl>();
            services.AddTransient<SettingControl>();

            ServiceProvider = services.BuildServiceProvider();
            ApplicationConfiguration.Initialize();
            using var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            if(loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(ServiceProvider.GetRequiredService<MainForm>());
            }
        }
    }
}