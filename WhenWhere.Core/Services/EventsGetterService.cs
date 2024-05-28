using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Core.DTO;
using WhenWhere.Core.ServiceContracts;

namespace WhenWhere.Core.Services
{
    public class EventsGetterService : IEventsGetterService
    {
        private readonly IEventsRepository? _eventsRepository;

        public EventsGetterService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<IEnumerable<EventResponse>?> GetAllEvents(string? userId)
        {
            if (userId == null)
            {
                return null;
            }

            return await _eventsRepository.GetAllEvents(userId)?.Select(e => e.ToEventResponse())
                                          .ToListAsync();
        }

        public async Task<IEnumerable<EventResponse>?> GetCreatedEvents(string? userId)
        {
            if (userId == null)
            {
                return null;
            }

            return await _eventsRepository.GetCreatedEvents(userId)?.Select(e => e.ToEventResponse())
                                          .ToListAsync();
        }

        public async Task<IEnumerable<EventResponse>?> GetRegisteredEvents(string? userId)
        {
            if (userId == null)
            {
                return null;
            }

            return await _eventsRepository.GetRegisteredEvents(userId)?.Select(e => e.ToEventResponse())
                                          .ToListAsync();
        }
    }
}
