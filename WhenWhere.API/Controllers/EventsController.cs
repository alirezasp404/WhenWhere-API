using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhenWhere.Core.Domain.Entities;
using WhenWhere.Core.DTO;
using WhenWhere.Core.Enums;
using WhenWhere.Core.ServiceContracts;
using WhenWhere.Core.Services;

namespace WhenWhere.API.Controllers
{
    public class EventsController : APIController
    {
        private readonly IEventsGetterService _eventsGetterService;
        private readonly IEventsAdderService _eventsAdderService;
        private readonly IEventsDeleterService _eventsDeleterService;

        public EventsController(IEventsGetterService eventsGetterService,
                                IEventsAdderService eventsAdderService,
                                IEventsDeleterService eventsDeleterService)
        {
            _eventsGetterService = eventsGetterService;
            _eventsAdderService = eventsAdderService;
            _eventsDeleterService = eventsDeleterService;
        }

        [HttpPost]
        public async Task<ActionResult<EventResponse>> CreateEvent(EventAddRequest? eventAddRequest)
        {
            eventAddRequest.EventCreatorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _eventsAdderService.AddEvent(eventAddRequest);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponse>>> GetAllEvents()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var allEvents = await _eventsGetterService.GetAllEvents(userId);
            if (allEvents is null)
            {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: "There aren't any Events");
            }

            return Ok(allEvents);
        }

        [HttpGet("createdByUser")]
        public async Task<ActionResult<IEnumerable<EventResponse>>> GetCreatedEvents()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var createdEvents = await _eventsGetterService.GetCreatedEvents(userId);
            if (createdEvents is null)
            {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: "There aren't any Created Events");
            }

            return Ok(createdEvents);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvents(Guid? eventId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            bool eventDeleted = await _eventsDeleterService.DeleteEvent(eventId, userId);
            if (!eventDeleted)
            {
                return Problem(detail: "There aren't any events with given Id to delete", statusCode: StatusCodes.Status404NotFound);
            }

            return NoContent();
        }
    }
}
