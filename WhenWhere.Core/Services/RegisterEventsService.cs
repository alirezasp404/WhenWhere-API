using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WhenWhere.Core.Domain.Entities;
using WhenWhere.Core.Domain.RepositoryContracts;
using WhenWhere.Core.Exceptions;
using WhenWhere.Core.Helpers;
using WhenWhere.Core.ServiceContracts;

namespace WhenWhere.Core.Services
{
    public class RegisterEventsService : IRegisterEventsService
    {
        private readonly IEventsRepository _eventsRepository;

        public RegisterEventsService(IEventsRepository eventsRepository)
        {
            this._eventsRepository = eventsRepository;
        }

        public async Task RegisterEvent(Guid? eventId, string? userId)
        {
            ArgumentNullException.ThrowIfNull(eventId);
            Event foundEvent = _eventsRepository.GetEventById(eventId)?.Result;
            ArgumentNullException.ThrowIfNull(foundEvent);
            if (foundEvent.Capacity <= 0)
                throw new FullCapacityException("There is no capacity to register for this event");
            RegisteredEvent RegisteredEvent = new RegisteredEvent()
            {
                EventId = eventId,
                UserId = userId,
            };
            await _eventsRepository.RegisterForEvent(RegisteredEvent);
            foundEvent.Capacity--;
        }
    }
}
