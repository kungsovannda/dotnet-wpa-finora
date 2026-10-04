using System;
using System.Collections.Generic;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Features.Transactions
{
    /// <summary>Aggregate read model: how much of one kind of money, over one period.</summary>
    public class MoneyTotal
    {
        public string Key { get; set; } = string.Empty;

        public long KeyId { get; set; }

        public decimal Total { get; set; }

        public int Count { get; set; }
    }

    /// <summary>Aggregate read model: one calendar month of activity.</summary>
    public class MonthTotal
    {
        public int Month { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public int Count { get; set; }
    }

    /// <summary>
    /// Aggregate read model: one payment method. The method itself is carried
    /// through rather than as a number, because it is stored as text and a
    /// cast back from an integer would not survive the grouping.
    /// </summary>
    public class MethodTotal
    {
        public PaymentMethod PaymentMethod { get; set; }

        public decimal Total { get; set; }

        public int Count { get; set; }
    }

    public interface TransactionRepository
    {
        Transaction Save(Transaction transaction);

        Transaction? FindById(long id);

        List<Transaction> FindAll();

        List<Transaction> FindByCategory(long categoryId);

        /// <summary>Search, filter and sort in the database rather than in the UI.</summary>
        List<Transaction> Find(TransactionFilter filter);

        Transaction? Update(Transaction transaction);

        void Delete(long id);

        bool ExistsById(long id);

        int Count(DateTime? from = null, DateTime? to = null);

        decimal SumAmount(TransactionType type, DateTime? from = null, DateTime? to = null);

        /// <summary>Expense grouped by category, largest first. Aggregated in the database.</summary>
        List<MoneyTotal> SumExpensesByCategory(DateTime? from = null, DateTime? to = null);

        /// <summary>Income and expense grouped by calendar month of a single year.</summary>
        List<MonthTotal> SumByMonth(int year);

        /// <summary>Amounts grouped by payment method, largest first.</summary>
        List<MethodTotal> SumByPaymentMethod(DateTime? from = null, DateTime? to = null);
    }
}
