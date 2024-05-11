namespace WhenWhere.Infrastructure.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using WhenWhere.Core.Domain.Entities;

    /// <summary>
    /// Store application database context.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<RegisteredEvent> RegisteredEvents => Set<RegisteredEvent>();

        public DbSet<Event> Events => Set<Event>();
    }
}
