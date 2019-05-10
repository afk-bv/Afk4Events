using Afk4Events.Api.Util;
using Afk4Events.Models.Events;
using Afk4Events.Service.Events;
using Microsoft.AspNetCore.Mvc;

namespace Afk4Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : AfkControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventDto eventDto)
        {
            _eventService.CreateEvent(eventDto, UserId);

            return Ok();
        }
    }
}