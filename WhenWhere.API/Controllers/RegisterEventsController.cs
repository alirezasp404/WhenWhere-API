using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhenWhere.Core.DTO;
using WhenWhere.Core.Exceptions;
using WhenWhere.Core.ServiceContracts;
using WhenWhere.Core.Services;

namespace WhenWhere.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterEventsController : ControllerBase
    {
        private readonly IEventsGetterService _eventsGetterService;
        private readonly IRegisterEventsService _registerEventsService;

        public RegisterEventsController(IEventsGetterService eventsGetterService,IRegisterEventsService registerEventsService)
        {
            this._eventsGetterService = eventsGetterService;
            this._registerEventsService = registerEventsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponse>>> GetRegisteredEvents()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var registeredEvents = await _eventsGetterService.GetRegisteredEvents(userId);
            if (registeredEvents is null || !registeredEvents.Any())
            {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: "There aren't any Registered Events");
            }

            return Ok(registeredEvents);
        }

        [HttpPost]
        public async Task<ActionResult<EventResponse>> RegisterEvent( [FromBody] Guid? eventId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
            await _registerEventsService.RegisterEvent(eventId, userId);

            }catch (ArgumentNullException ex) {
                return Problem(detail: "There aren't any events with given Id", statusCode: StatusCodes.Status404NotFound);
            }catch (ArgumentException ex ) {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }

            return NoContent();
        }
    }
}
