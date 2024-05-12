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

        public async IEnumerable<EventResponse>? GetAllEvents(Guid? userId)
        {
            if (userId == null)
            {
                return null;
            }

            var allEvents = await _eventsRepository!.GetAllEvents(userId);
            return allEvents?.Select(e => e.ToEventResponse)
        }

        public IEnumerable<EventResponse>? GetCreatedEvents(Guid? userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventResponse>? GetRegisteredEvents(Guid? userId)
        {
            throw new NotImplementedException();
        }

        public UserProfile? GetUserProfile(Guid? userId)
        {
            throw new NotImplementedException();
        }
    }
}
