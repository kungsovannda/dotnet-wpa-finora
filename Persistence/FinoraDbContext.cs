using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Domains;

namespace PersonalExpenseTracker.Persistence
{
    /// <summary>
    /// The single mapped model behind every repository. Scoped, so a session
    /// tracks entities and a failed save can be rolled back without leaking
    /// state into the next unit of work.
    /// </summary>
    public class FinoraDbContext : DbContext
    {
        public FinoraDbContext(DbContextOptions<FinoraDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Transaction> Transactions => Set<Transaction>();

        public DbSet<SavingGoal> SavingGoals => Set<SavingGoal>();

        public DbSet<SavingGoalContribution> SavingGoalContributions => Set<SavingGoalContribution>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(user =>
            {
                user.ToTable("Users");
                user.HasKey(u => u.Id);
                user.Property(u => u.Id).ValueGeneratedOnAdd();
                user.Property(u => u.Username).IsRequired().HasMaxLength(64);
                user.Property(u => u.Password).IsRequired().HasMaxLength(128);
                user.Property(u => u.FirstName).HasMaxLength(64);
                user.Property(u => u.LastName).HasMaxLength(64);
                user.Property(u => u.Email).HasMaxLength(128);
                user.HasIndex(u => u.Username).IsUnique();

                user.HasMany(u => u.Categories)
                    .WithOne()
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                user.HasMany(u => u.Transactions)
                    .WithOne()
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                user.HasMany(u => u.SavingGoals)
                    .WithOne()
                    .HasForeignKey(g => g.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Category>(category =>
            {
                category.ToTable("Categories");
                category.HasKey(c => c.Id);
                category.Property(c => c.Id).ValueGeneratedOnAdd();
                category.Property(c => c.Name).IsRequired().HasMaxLength(100);
                category.Property(c => c.Description).HasMaxLength(255);
                category.Property(c => c.Emoji).HasMaxLength(16);
                category.Property(c => c.Type).HasConversion<string>().HasMaxLength(16);
                category.Property(c => c.CreatedAt).IsRequired();
                category.HasIndex(c => c.Name).IsUnique();

                // Restrict, not Cascade: a category is a label on transactions, and
                // removing the label must never remove the money record. The
                // service blocks the delete first, so this is only a backstop for
                // anything that reaches the database another way.
                category.HasMany(c => c.Transactions)
                    .WithOne(t => t.Category)
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Transaction>(transaction =>
            {
                transaction.ToTable("Transactions");
                transaction.HasKey(t => t.Id);
                transaction.Property(t => t.Id).ValueGeneratedOnAdd();
                transaction.Property(t => t.Type).HasConversion<string>().HasMaxLength(16);
                transaction.Property(t => t.PaymentMethod).HasConversion<string>().HasMaxLength(24);
                transaction.Property(t => t.Description).HasMaxLength(255);
                transaction.Property(t => t.Reference).HasMaxLength(64);
                transaction.Property(t => t.Merchant).HasMaxLength(120);
                transaction.Property(t => t.Date).IsRequired();
                transaction.Property(t => t.CreatedAt).IsRequired();
                transaction.HasIndex(t => t.Date);
                transaction.HasIndex(t => t.CategoryId);
            });

            builder.Entity<SavingGoal>(goal =>
            {
                goal.ToTable("SavingGoals");
                goal.HasKey(g => g.Id);
                goal.Property(g => g.Id).ValueGeneratedOnAdd();
                goal.Property(g => g.Name).IsRequired().HasMaxLength(100);
                goal.Property(g => g.Description).HasMaxLength(255);
                goal.Property(g => g.Emoji).HasMaxLength(16);
                goal.Property(g => g.TargetAmount).IsRequired();
                goal.Property(g => g.CurrentAmount).IsRequired();
                goal.Property(g => g.CreatedAt).IsRequired();
                goal.HasIndex(g => g.Name).IsUnique();

                goal.HasMany(g => g.Contributions)
                    .WithOne(c => c.SavingGoal)
                    .HasForeignKey(c => c.SavingGoalId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<SavingGoalContribution>(contribution =>
            {
                contribution.ToTable("SavingGoalContributions");
                contribution.HasKey(c => c.Id);
                contribution.Property(c => c.Id).ValueGeneratedOnAdd();
                contribution.Property(c => c.Amount).IsRequired();
                contribution.Property(c => c.Note).HasMaxLength(255);
                contribution.Property(c => c.Date).IsRequired();
                contribution.Property(c => c.CreatedAt).IsRequired();
                contribution.HasIndex(c => c.SavingGoalId);
            });
        }
    }
}
