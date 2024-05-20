namespace WhenWhere.Infrastructure.DataContext
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WhenWhere.Core.Domain.Entities;
    using WhenWhere.Core.Domain.IdentityEntities;

    /// <summary>
    /// Store application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<RegisteredEvent> RegisteredEvents => Set<RegisteredEvent>();

        public DbSet<Event> Events => Set<Event>();
    }
}
