using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Utils;

namespace PersonalExpenseTracker.Persistence
{

    public static class DatabaseInitializer
    {
        public const string DefaultUsername = "admin";
        public const string DefaultPassword = "admin123";

        public static void Initialize(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<FinoraDbContext>();

            db.Database.Migrate();

            if (db.Users.Any())
                return;

            Seed(db);
        }

        private static void Seed(FinoraDbContext db)
        {
            var user = new User
            {
                Username = DefaultUsername,
                Password = PasswordHasher.Hash(DefaultPassword),
                FirstName = "Finora",
                LastName = "User",
                Email = "you@finora.app"
            };

            db.Users.Add(user);
            db.SaveChanges();

            var now = DateTime.Now;

            var groceries = AddCategory(db, user.Id, "Groceries & Food", "Weekly shop and eating out", "🛒", TransactionType.EXPENSE);
            var transport = AddCategory(db, user.Id, "Transport", "Fuel, fares and parking", "🚗", TransactionType.EXPENSE);
            var shopping = AddCategory(db, user.Id, "Shopping", "Clothes, home and gifts", "🛍️", TransactionType.EXPENSE);
            var subscriptions = AddCategory(db, user.Id, "Subscriptions", "Streaming and software", "📺", TransactionType.EXPENSE);
            var bills = AddCategory(db, user.Id, "Bills & Home", "Rent, utilities and insurance", "🏠", TransactionType.EXPENSE);
            var salary = AddCategory(db, user.Id, "Salary", "Monthly pay", "💼", TransactionType.INCOME);
            var freelance = AddCategory(db, user.Id, "Freelance", "Project and consulting work", "🧑‍💻", TransactionType.INCOME);

            AddTransaction(db, user.Id, salary, TransactionType.INCOME, 3200.00m, now.AddMonths(-2).AddDays(-1), "Monthly salary", PaymentMethod.BANK_TRANSFER, "PAY-2024-11", "Northwind Ltd");
            AddTransaction(db, user.Id, salary, TransactionType.INCOME, 3200.00m, now.AddMonths(-1).AddDays(-1), "Monthly salary", PaymentMethod.BANK_TRANSFER, "PAY-2024-12", "Northwind Ltd");
            AddTransaction(db, user.Id, freelance, TransactionType.INCOME, 640.00m, now.AddDays(-12), "Landing page build", PaymentMethod.CREDIT_CARD, string.Empty, "Studio Nine");
            AddTransaction(db, user.Id, groceries, TransactionType.EXPENSE, 128.45m, now.AddDays(-6), "Weekly grocery run", PaymentMethod.DEBIT_CARD, string.Empty, "Market Street");
            AddTransaction(db, user.Id, transport, TransactionType.EXPENSE, 64.20m, now.AddDays(-4), "Fuel and parking", PaymentMethod.CREDIT_CARD, string.Empty, "Shell");
            AddTransaction(db, user.Id, shopping, TransactionType.EXPENSE, 89.99m, now.AddDays(-3), "Running shoes", PaymentMethod.CREDIT_CARD, string.Empty, "Trailhead");
            AddTransaction(db, user.Id, subscriptions, TransactionType.EXPENSE, 27.99m, now.AddDays(-2), "Streaming and design tools", PaymentMethod.CREDIT_CARD, string.Empty, string.Empty);
            AddTransaction(db, user.Id, bills, TransactionType.EXPENSE, 1450.00m, now.AddDays(-1), "Rent", PaymentMethod.BANK_TRANSFER, string.Empty, string.Empty);
            AddTransaction(db, user.Id, groceries, TransactionType.EXPENSE, 42.30m, now, "Coffee and pastries", PaymentMethod.MOBILE_WALLET, string.Empty, "Bean & Co");

            var emergency = new SavingGoal
            {
                UserId = user.Id,
                Name = "Emergency Fund",
                Emoji = "🛟",
                Description = "Three months of expenses set aside",
                TargetAmount = 4000.00m,
                CurrentAmount = 850.00m,
                TargetDate = now.AddMonths(8),
                CreatedAt = now.AddMonths(-4)
            };

            var laptop = new SavingGoal
            {
                UserId = user.Id,
                Name = "New Laptop",
                Emoji = "💻",
                Description = "Replacement for the ageing work machine",
                TargetAmount = 1500.00m,
                CurrentAmount = 1500.00m,
                TargetDate = now.AddMonths(-1),
                CreatedAt = now.AddMonths(-5)
            };

            db.SavingGoals.AddRange(emergency, laptop);
            db.SaveChanges();

            db.SavingGoalContributions.AddRange(
                new SavingGoalContribution
                {
                    SavingGoalId = emergency.Id,
                    Amount = 400.00m,
                    Date = now.AddMonths(-3),
                    Note = "Opened the account",
                    CreatedAt = now.AddMonths(-3)
                },
                new SavingGoalContribution
                {
                    SavingGoalId = emergency.Id,
                    Amount = 250.00m,
                    Date = now.AddMonths(-2),
                    Note = "Standing order",
                    CreatedAt = now.AddMonths(-2)
                },
                new SavingGoalContribution
                {
                    SavingGoalId = emergency.Id,
                    Amount = 200.00m,
                    Date = now.AddDays(-20),
                    Note = "Bonus top-up",
                    CreatedAt = now.AddDays(-20)
                },
                new SavingGoalContribution
                {
                    SavingGoalId = laptop.Id,
                    Amount = 1500.00m,
                    Date = now.AddMonths(-1),
                    Note = "Fully funded",
                    CreatedAt = now.AddMonths(-1)
                });

            db.SaveChanges();
        }

        private static Category AddCategory(FinoraDbContext db, long userId, string name, string description, string emoji, TransactionType type)
        {
            var category = new Category
            {
                UserId = userId,
                Name = name,
                Description = description,
                Emoji = emoji,
                Type = type,
                CreatedAt = DateTime.Now
            };

            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }

        private static void AddTransaction(
            FinoraDbContext db,
            long userId,
            Category category,
            TransactionType type,
            decimal amount,
            DateTime date,
            string description,
            PaymentMethod method,
            string reference,
            string merchant)
        {
            db.Transactions.Add(new Transaction
            {
                UserId = userId,
                Category = category,
                CategoryId = category.Id,
                Type = type,
                Amount = amount,
                Date = date,
                Description = description,
                PaymentMethod = method,
                Reference = reference,
                Merchant = merchant,
                CreatedAt = date
            });
        }
    }
}
