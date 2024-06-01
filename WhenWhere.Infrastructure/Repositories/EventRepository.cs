using Microsoft.EntityFrameworkCore;
using WhenWhere.Core.Domain.Entities;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Core.Exceptions;
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

        public IQueryable<Event>? GetAllEvents(string? userId)
        {
            return _dbContext.Events.Include(nameof(Event.EventCreator))
                                    .Where(e => e.EventCreatorId != userId && e.ExpiredAt > DateTime.Now);
        }

        public IQueryable<Event> GetCreatedEvents(string? userId)
        {
            return _dbContext.Events.Where(e => e.EventCreatorId == userId);
        }

        public async Task<Event?>? GetEventById(Guid? eventId)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public IQueryable<Event?>? GetRegisteredEvents(string? userId)
        {
            return _dbContext.RegisteredEvents?.Include(nameof(Event))
                                              .Where(e => e.UserId == userId)
                                              .Select(e => e.Event);
        }

        public async Task RegisterForEvent(RegisteredEvent registeredEvent)
        {
            var registered = _dbContext.RegisteredEvents.FirstOrDefaultAsync(e => e.UserId == registeredEvent.UserId && e.EventId == registeredEvent.EventId).Result;
            if (registered is not null)
            {
                throw new UserAlreadyRegisteredException("The user has already registered for this event");
            }

            _dbContext.Add(registeredEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}
