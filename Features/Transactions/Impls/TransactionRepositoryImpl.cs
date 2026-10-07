using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Persistence;

namespace PersonalExpenseTracker.Features.Transactions.Impls
{
    public class TransactionRepositoryImpl : TransactionRepository
    {
        private readonly FinoraDbContext _db;
        private readonly CurrentUserSession _session;

        public TransactionRepositoryImpl(FinoraDbContext db, CurrentUserSession session)
        {
            _db = db;
            _session = session;
        }

        public Transaction Save(Transaction transaction)
        {
            transaction.CreatedAt = DateTime.Now;
            transaction.UserId ??= _session.UserId;
            _db.Transactions.Add(transaction);
            _db.SaveChanges();
            return transaction;
        }

        public Transaction? FindById(long id)
        {
            return Owned(_db.Transactions)
                .Include(t => t.Category)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<Transaction> FindAll()
        {
            return Owned(_db.Transactions)
                .Include(t => t.Category)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        public List<Transaction> FindByCategory(long categoryId)
        {
            return Owned(_db.Transactions)
                .Include(t => t.Category)
                .Where(t => t.CategoryId == categoryId)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        public List<Transaction> Find(TransactionFilter filter)
        {
            // Include() returns IIncludableQueryable, which none of the operators
            // below hand back, so the chain is held as a plain IQueryable.
            IQueryable<Transaction> query = Owned(_db.Transactions).Include(t => t.Category);

            if (filter == null)
                return query.OrderByDescending(t => t.Date).ToList();

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var pattern = LikeContains(filter.Search.Trim());
                query = query.Where(t =>
                    EF.Functions.Like(t.Description, pattern, "\\") ||
                    EF.Functions.Like(t.Reference, pattern, "\\") ||
                    EF.Functions.Like(t.Merchant, pattern, "\\") ||
                    EF.Functions.Like(t.Category!.Name, pattern, "\\"));
            }

            if (filter.Type.HasValue)
            {
                var type = filter.Type.Value;
                query = query.Where(t => t.Type == type);
            }

            if (filter.CategoryId.HasValue)
            {
                var categoryId = filter.CategoryId.Value;
                query = query.Where(t => t.CategoryId == categoryId);
            }

            if (filter.PaymentMethod.HasValue)
            {
                var method = filter.PaymentMethod.Value;
                query = query.Where(t => t.PaymentMethod == method);
            }

            if (filter.From.HasValue)
            {
                var from = filter.From.Value.Date;
                query = query.Where(t => t.Date >= from);
            }

            if (filter.To.HasValue)
            {
                query = query.Where(t => t.Date < ExclusiveEnd(filter.To.Value));
            }

            query = filter.Sort switch
            {
                TransactionSort.OldestFirst => query.OrderBy(t => t.Date).ThenByDescending(t => t.Id),
                TransactionSort.HighestAmount => query.OrderByDescending(t => t.Amount).ThenByDescending(t => t.Date),
                TransactionSort.LowestAmount => query.OrderBy(t => t.Amount).ThenByDescending(t => t.Date),
                _ => query.OrderByDescending(t => t.Date).ThenByDescending(t => t.Id)
            };

            return query.ToList();
        }

        public Transaction? Update(Transaction transaction)
        {
            var existingTransaction = Owned(_db.Transactions).FirstOrDefault(t => t.Id == transaction.Id);
            if (existingTransaction == null)
                return null;

            existingTransaction.CategoryId = transaction.CategoryId;
            existingTransaction.Category = transaction.Category;
            existingTransaction.Type = transaction.Type;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Date = transaction.Date;
            existingTransaction.Description = transaction.Description;
            existingTransaction.PaymentMethod = transaction.PaymentMethod;
            existingTransaction.Reference = transaction.Reference;
            existingTransaction.Merchant = transaction.Merchant;
            existingTransaction.UpdatedAt = DateTime.Now;
            _db.SaveChanges();
            return existingTransaction;
        }

        public void Delete(long id)
        {
            var transaction = Owned(_db.Transactions).FirstOrDefault(t => t.Id == id);
            if (transaction != null)
            {
                // Soft delete: the money record is kept for later reporting; it
                // is simply no longer returned by any live query.
                transaction.IsDeleted = true;
                _db.SaveChanges();
            }
        }

        public bool ExistsById(long id)
        {
            return Owned(_db.Transactions).Any(t => t.Id == id);
        }

        public int Count(DateTime? from = null, DateTime? to = null)
        {
            return InPeriod(from, to).Count();
        }

        public decimal SumAmount(TransactionType type, DateTime? from = null, DateTime? to = null)
        {
            return InPeriod(from, to).Where(t => t.Type == type).Sum(t => t.Amount);
        }

        public List<MoneyTotal> SumExpensesByCategory(DateTime? from = null, DateTime? to = null)
        {
            return InPeriod(from, to)
                .Where(t => t.Type == TransactionType.EXPENSE)
                .GroupBy(t => new { t.CategoryId, Name = t.Category!.Name })
                .Select(g => new MoneyTotal
                {
                    KeyId = g.Key.CategoryId,
                    Key = g.Key.Name,
                    Total = g.Sum(t => t.Amount),
                    Count = g.Count()
                })
                .OrderByDescending(m => m.Total)
                .ToList();
        }

        public List<MonthTotal> SumByMonth(int year)
        {
            return Owned(_db.Transactions)
                .Where(t => t.Date.Year == year)
                .GroupBy(t => t.Date.Month)
                .Select(g => new MonthTotal
                {
                    Month = g.Key,
                    TotalIncome = g.Where(t => t.Type == TransactionType.INCOME).Sum(t => t.Amount),
                    TotalExpense = g.Where(t => t.Type == TransactionType.EXPENSE).Sum(t => t.Amount),
                    Count = g.Count()
                })
                .OrderBy(m => m.Month)
                .ToList();
        }

        public List<MethodTotal> SumByPaymentMethod(DateTime? from = null, DateTime? to = null)
        {
            return InPeriod(from, to)
                .GroupBy(t => t.PaymentMethod)
                .Select(g => new MethodTotal
                {
                    PaymentMethod = g.Key,
                    Total = g.Sum(t => t.Amount),
                    Count = g.Count()
                })
                .OrderByDescending(m => m.Total)
                .ToList();
        }

        private IQueryable<Transaction> InPeriod(DateTime? from, DateTime? to)
        {
            var query = Owned(_db.Transactions);

            if (from.HasValue)
            {
                var start = from.Value.Date;
                query = query.Where(t => t.Date >= start);
            }

            if (to.HasValue)
            {
                query = query.Where(t => t.Date < ExclusiveEnd(to.Value));
            }

            return query;
        }

        /// <summary>
        /// End of the chosen day, inclusive. Adding a day to the last representable
        /// date would overflow, so that case is compared directly instead.
        /// </summary>
        private static DateTime ExclusiveEnd(DateTime to)
        {
            var day = to.Date;
            return day < DateTime.MaxValue.Date ? day.AddDays(1) : day;
        }

        /// <summary>
        /// Restricts a read to the signed-in account. Rows with no owner are
        /// included because they predate the ownership column; a session with
        /// no account at all sees nothing, because nothing in the app can reach
        /// a page without having signed in first.
        /// </summary>
        private IQueryable<Transaction> Owned(IQueryable<Transaction> query)
        {
            query = _session.UserId.HasValue
                ? query.Where(t => t.UserId == _session.UserId.Value || t.UserId == null)
                : query.Where(t => false);

            // Soft-deleted rows stay in the table but leave every read: they
            // exist so nothing is ever orphaned, and no page shows them again.
            return query.Where(t => !t.IsDeleted);
        }

        /// <summary>
        /// A contains-anywhere pattern for <c>EF.Functions.Like</c>. SQLite's
        /// LIKE folds ASCII case, which is what the search box needs;
        /// <c>string.Contains</c> is translated to <c>instr</c> instead, and
        /// that one is case-sensitive. Wildcards a user can type are escaped so
        /// a literal % in a search term only ever matches itself.
        /// </summary>
        private static string LikeContains(string term)
        {
            var escaped = term
                .Replace("\\", "\\\\")
                .Replace("%", "\\%")
                .Replace("_", "\\_");

            return "%" + escaped + "%";
        }
    }
}
