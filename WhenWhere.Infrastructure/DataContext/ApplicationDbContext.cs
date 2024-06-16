using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhenWhere.Core.Domain.Entities;
using WhenWhere.Core.Domain.IdentityEntities;

namespace WhenWhere.Infrastructure.DataContext
{
    /// <summary>
    /// Store application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<RegisteredEvent> RegisteredEvents => Set<RegisteredEvent>();

        public DbSet<Event> Events => Set<Event>();
    }
}
