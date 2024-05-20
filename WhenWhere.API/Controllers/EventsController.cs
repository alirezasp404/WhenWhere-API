using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhenWhere.Core.DTO;
using WhenWhere.Core.ServiceContracts;

namespace WhenWhere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsGetterService eventsGetterService;

        public EventsController(IEventsGetterService eventsGetterService)
        {
            this.eventsGetterService = eventsGetterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponse>>> Get()
        {
            Guid userId =new Guid();
            var a = await eventsGetterService.GetAllEvents(userId);
            return a;

        }

    }
}
