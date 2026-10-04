using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PersonalExpenseTracker.Persistence
{

    public class FinoraDbContextFactory : IDesignTimeDbContextFactory<FinoraDbContext>
    {
        public FinoraDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<FinoraDbContext>()
                .UseSqlite($"Data Source={DatabasePaths.DefaultConnectionStringPath}")
                .Options;

            return new FinoraDbContext(options);
        }
    }
}
