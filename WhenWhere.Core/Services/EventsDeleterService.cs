using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Core.Exceptions;
using WhenWhere.Core.ServiceContracts;

namespace WhenWhere.Core.Services
{
    public class EventsDeleterService : IEventsDeleterService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsDeleterService(IEventsRepository eventsRepository)
        {
            this._eventsRepository = eventsRepository;
        }
        public async Task<bool> DeleteEvent(Guid? eventId, string? userId)
        {
            var eventToDelete = await _eventsRepository.GetEventById(eventId);
            if (eventToDelete is not null && eventToDelete.EventCreatorId == userId)
            {
                _eventsRepository.DeleteEvent(eventToDelete);
                return true;
            }
            return false;
        }

    }
}
