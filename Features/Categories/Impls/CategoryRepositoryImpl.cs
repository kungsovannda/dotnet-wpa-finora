using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Persistence;

namespace PersonalExpenseTracker.Features.Categories.Impls
{
    public class CategoryRepositoryImpl : CategoryRepository
    {
        private readonly FinoraDbContext _db;
        private readonly CurrentUserSession _session;

        public CategoryRepositoryImpl(FinoraDbContext db, CurrentUserSession session)
        {
            _db = db;
            _session = session;
        }

        public Category Save(Category category)
        {
            category.CreatedAt = DateTime.Now;
            category.UserId ??= _session.UserId;
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }

        public Category? FindById(long id)
        {
            return Owned(_db.Categories).FirstOrDefault(c => c.Id == id);
        }

        public List<Category> FindAll()
        {
            return Owned(_db.Categories).OrderBy(c => c.Id).ToList();
        }

        public Category? Update(Category category)
        {
            var existingCategory = Owned(_db.Categories).FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
                return null;

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.Emoji = category.Emoji;
            _db.SaveChanges();
            return existingCategory;
        }

        public void Delete(long id)
        {
            var category = Owned(_db.Categories).FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                // Soft delete: the row stays so transactions that already carry
                // this label keep their history; every read filters it out.
                category.IsDeleted = true;
                _db.SaveChanges();
            }
        }

        public bool ExistsByName(string name)
        {
            // SQLite's NOCASE collation only folds ASCII, while the original
            // check was a full OrdinalIgnoreCase comparison, which EF cannot
            // translate. The user scoping still runs in SQL; only the candidate
            // names come back to be compared here.
            return Owned(_db.Categories)
                .AsNoTracking()
                .Select(c => c.Name)
                .AsEnumerable()
                .Any(existing => existing.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool ExistsById(long id)
        {
            return Owned(_db.Categories).Any(c => c.Id == id);
        }

        public int CountTransactions(long categoryId)
        {
            // Counted in SQL, and across every account, not just the caller's: a
            // category is shared data, so one user's transactions can pin it for
            // everyone. Only live transactions pin: rows the user has already
            // deleted are hidden, so they must not block a deletion either.
            return _db.Transactions.Count(t => t.CategoryId == categoryId && !t.IsDeleted);
        }

        /// <summary>
        /// Restricts a read to the signed-in account. Rows with no owner are
        /// included because they predate the ownership column; a session with
        /// no account at all sees nothing, because nothing in the app can reach
        /// a page without having signed in first.
        /// </summary>
        private IQueryable<Category> Owned(IQueryable<Category> query)
        {
            query = _session.UserId.HasValue
                ? query.Where(c => c.UserId == _session.UserId.Value || c.UserId == null)
                : query.Where(c => false);

            // Every read is a live read: soft-deleted rows exist only so the
            // history they label is never orphaned, and nothing in the app needs
            // to see them again.
            return query.Where(c => !c.IsDeleted);
        }
    }
}
