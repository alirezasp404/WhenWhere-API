using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhenWhere.Core.Domain.Entities;

namespace WhenWhere.Infrastructure.DataContext
{
    /// <summary>
    /// Store application database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<RegisteredEvent> RegisteredEvents => Set<RegisteredEvent>();

        public DbSet<Event> Events => Set<Event>();
    }
}
