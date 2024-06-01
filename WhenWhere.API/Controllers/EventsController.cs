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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsGetterService _eventsGetterService;
        private readonly IEventsAdderService _eventsAdderService;

        public EventsController(IEventsGetterService eventsGetterService,
                                IEventsAdderService eventsAdderService)
        {
            _eventsGetterService = eventsGetterService;
            _eventsAdderService = eventsAdderService;
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
            if (allEvents is null || !allEvents.Any())
            {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: "There aren't any Events");
            }

            return Ok(allEvents);
        }

        [HttpGet("createdByUser")]
        public async Task<ActionResult<IEnumerable<EventResponse>>> GetAllCreatedEvents()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var createdEvents = await _eventsGetterService.GetCreatedEvents(userId);
            if (createdEvents is null || !createdEvents.Any())
            {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: "There aren't any Created Events");
            }

            return Ok(createdEvents);
        }
    }
}
