using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Features.Authentication.Impls;
using PersonalExpenseTracker.Features.Categories;
using PersonalExpenseTracker.Features.Categories.Impls;
using PersonalExpenseTracker.Features.Dashboard;
using PersonalExpenseTracker.Features.Dashboard.Impls;
using PersonalExpenseTracker.Features.SavingGoals;
using PersonalExpenseTracker.Features.SavingGoals.Impls;
using PersonalExpenseTracker.Features.Transactions;
using PersonalExpenseTracker.Features.Transactions.Impls;
using PersonalExpenseTracker.Persistence;
using PersonalExpenseTracker.Views.Data;
using PersonalExpenseTracker.Views.Forms;

namespace PersonalExpenseTracker
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; } = null!;

        /// <summary>
        ///  The main entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // One connection to the local SQLite file. Scoped, so the change
            // tracker lives for a single unit of work rather than for the
            // lifetime of the process.
            services.AddDbContext<FinoraDbContext>(options =>
                options.UseSqlite($"Data Source={DatabasePaths.DefaultConnectionStringPath}"));

            // Who is signed in. Session state, not a unit of work, so it outlives
            // the scope and is cleared explicitly on logout.
            services.AddSingleton<CurrentUserSession>();

            // Register Repository implementations
            services.AddScoped<CategoryRepository, CategoryRepositoryImpl>();
            services.AddScoped<TransactionRepository, TransactionRepositoryImpl>();
            services.AddScoped<UserRepository, UserRepositoryImpl>();
            services.AddScoped<SavingGoalRepository, SavingGoalRepositoryImpl>();

            // Register Service implementations
            services.AddScoped<CategoryService, CategoryServiceImpl>();
            services.AddScoped<TransactionService, TransactionServiceImpl>();
            services.AddScoped<AuthenticationService, AuthenticationServiceImpl>();
            services.AddScoped<DashboardService, DashboardServiceImpl>();
            services.AddScoped<ReportsService, ReportsServiceImpl>();
            services.AddScoped<SavingGoalService, SavingGoalServiceImpl>();

            // Register Controller implementations
            services.AddTransient<CategoryController>();
            services.AddTransient<TransactionController>();
            services.AddTransient<AuthenticationController>();
            services.AddTransient<DashboardController>();
            services.AddTransient<ReportsController>();
            services.AddTransient<SavingGoalController>();

            // Shared by the pages so a write on one page reaches the others.
            // Views-layer only: no controller, service or repository knows it exists.
            services.AddSingleton<DataChangeNotifier>();

            // Register Forms
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<DashboardControl>();
            services.AddTransient<TransactionControl>();
            services.AddTransient<CategoryControl>();
            services.AddTransient<SavingGoalControl>();
            services.AddTransient<ReportControl>();
            services.AddTransient<SettingControl>();

            // Dialogs that need a controller are resolved by the page that
            // opens them; the rest are plain forms built with `new`.
            services.AddTransient<TransactionDialog>();
            services.AddTransient<ChangePasswordDialog>();

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            DatabaseInitializer.Initialize(ServiceProvider);

            // A desktop session is single threaded, so one scope opened here and
            // held for the run gives every form the same context and the same
            // session state without threading a scope through the event handlers.
            using var scope = ServiceProvider.CreateScope();
            var session = scope.ServiceProvider;

            using var loginForm = session.GetRequiredService<LoginForm>();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(session.GetRequiredService<MainForm>());
            }
        }
    }
}
