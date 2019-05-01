using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Afk4Events.Data
{
    public class Afk4EventsContext : DbContext, IDataProtectionKeyContext
    {
        public Afk4EventsContext(DbContextOptions<Afk4EventsContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
#endif
        }
    }

    /// <summary>
    /// Used by EF to create model without API project
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<Afk4EventsContext>
    {
        public Afk4EventsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Afk4EventsContext>();
            optionsBuilder.UseNpgsql("Host=localhost:21337;Database=afk4events;Username=development;Password=development");

            return new Afk4EventsContext(optionsBuilder.Options);
        }
    }
}

