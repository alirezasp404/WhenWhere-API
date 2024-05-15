using Microsoft.EntityFrameworkCore;
using WhenWhere.Core.Domain.Entities;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Infrastructure.DataContext;

namespace WhenWhere.Infrastructure.Repositories
{
    /// <summary>
    /// Event repository for access database.
    /// </summary>
    public class EventRepository : IEventsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEvent(Event eventModel)
        {
            _dbContext.Add(eventModel);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Event>? GetAllEvents(Guid? userId)
        {
           return _dbContext.Events.Include(nameof(Event))
                                   .Where(e => e.EventCreatorId != userId);

        }

        public IQueryable<Event> GetCreatedEvents(Guid? userId)
        {
            return _dbContext.Events.Where(e => e.EventCreatorId == userId);
        }

        public IQueryable<Event?>? GetRegisteredEvents(Guid? userId)
        {
            return _dbContext.RegisteredEvents?.Include(nameof(Event))
                                              .Where(e => e.UserId == userId)
                                              .Select(e => e.Event);
        }

        public async Task RegisterForEvent(RegisteredEvent registeredEvent)
        {
            _dbContext.Add(registeredEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}
