using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenWhere.Core.Domain.Entities;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Core.DTO;
using WhenWhere.Core.Helpers;
using WhenWhere.Core.ServiceContracts;

namespace WhenWhere.Core.Services
{
    public class EventsAdderService : IEventsAdderService
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsAdderService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<EventResponse> AddEvent(EventAddRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            ValidationHelper.ModelValidation(request);
            var newEvent = request.ToEvent();
            await _eventsRepository.CreateEvent(newEvent);
            return newEvent.ToEventResponse();
        }
    }
}
