using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Domains;
using PersonalExpenseTracker.Features.Authentication;
using PersonalExpenseTracker.Persistence;

namespace PersonalExpenseTracker.Features.SavingGoals.Impls
{
    public class SavingGoalRepositoryImpl : SavingGoalRepository
    {
        private readonly FinoraDbContext _db;
        private readonly CurrentUserSession _session;

        public SavingGoalRepositoryImpl(FinoraDbContext db, CurrentUserSession session)
        {
            _db = db;
            _session = session;
        }

        public SavingGoal Save(SavingGoal goal)
        {
            goal.CreatedAt = DateTime.Now;
            goal.UserId ??= _session.UserId;
            _db.SavingGoals.Add(goal);
            _db.SaveChanges();
            return goal;
        }

        public SavingGoal? FindById(long id)
        {
            return Owned(_db.SavingGoals).FirstOrDefault(g => g.Id == id);
        }

        public List<SavingGoal> FindAll()
        {
            return Owned(_db.SavingGoals)
                .OrderByDescending(g => g.IsArchived)
                .ThenBy(g => g.TargetDate ?? DateTime.MaxValue)
                .ThenBy(g => g.Id)
                .ToList();
        }

        public List<SavingGoal> FindActive()
        {
            return Owned(_db.SavingGoals)
                .Where(g => !g.IsArchived)
                .OrderBy(g => g.TargetDate ?? DateTime.MaxValue)
                .ThenBy(g => g.Id)
                .ToList();
        }

        public SavingGoal? Update(SavingGoal goal)
        {
            var existing = Owned(_db.SavingGoals).FirstOrDefault(g => g.Id == goal.Id);
            if (existing == null)
                return null;

            existing.Name = goal.Name;
            existing.Description = goal.Description;
            existing.Emoji = goal.Emoji;
            existing.TargetAmount = goal.TargetAmount;
            existing.TargetDate = goal.TargetDate;
            existing.IsArchived = goal.IsArchived;
            existing.UpdatedAt = DateTime.Now;
            _db.SaveChanges();
            return existing;
        }

        public void Delete(long id)
        {
            var goal = Owned(_db.SavingGoals).FirstOrDefault(g => g.Id == id);
            if (goal != null)
            {
                // Soft delete: the goal (and with it the contribution history
                // that lives under it) is hidden, not removed.
                goal.IsDeleted = true;
                _db.SaveChanges();
            }
        }

        public List<SavingGoalContribution> FindContributions(long savingGoalId)
        {
            return _db.SavingGoalContributions
                .AsNoTracking()
                .Where(c => c.SavingGoalId == savingGoalId)
                .OrderByDescending(c => c.Date)
                .ThenByDescending(c => c.Id)
                .ToList();
        }

        public void AddContribution(SavingGoal goal, SavingGoalContribution contribution)
        {
            var stored = _db.SavingGoals.FirstOrDefault(g => g.Id == goal.Id && !g.IsDeleted)
                ?? throw new InvalidOperationException($"Saving goal {goal.Id} no longer exists.");

            contribution.SavingGoalId = stored.Id;
            contribution.CreatedAt = DateTime.Now;

            stored.CurrentAmount = goal.CurrentAmount;
            stored.UpdatedAt = DateTime.Now;

            _db.SavingGoalContributions.Add(contribution);
            _db.SaveChanges();
        }

        public void RemoveContribution(SavingGoal goal, long contributionId)
        {
            var stored = _db.SavingGoals.FirstOrDefault(g => g.Id == goal.Id && !g.IsDeleted)
                ?? throw new InvalidOperationException($"Saving goal {goal.Id} no longer exists.");

            var contribution = _db.SavingGoalContributions
                .FirstOrDefault(c => c.Id == contributionId && c.SavingGoalId == stored.Id);

            if (contribution == null)
                return;

            stored.CurrentAmount = goal.CurrentAmount;
            stored.UpdatedAt = DateTime.Now;

            _db.SavingGoalContributions.Remove(contribution);
            _db.SaveChanges();
        }

        /// <summary>
        /// Restricts a read to the signed-in account. Rows with no owner are
        /// included because they predate the ownership column; a session with
        /// no account at all sees nothing, because nothing in the app can reach
        /// a page without having signed in first.
        /// </summary>
        private IQueryable<SavingGoal> Owned(IQueryable<SavingGoal> query)
        {
            query = _session.UserId.HasValue
                ? query.Where(g => g.UserId == _session.UserId.Value || g.UserId == null)
                : query.Where(g => false);

            // Soft-deleted goals stay in the table but leave every read; their
            // contributions go with them because there is no other route to them.
            return query.Where(g => !g.IsDeleted);
        }
    }
}
