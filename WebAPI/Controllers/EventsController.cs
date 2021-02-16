using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventFacade _eventFacade;
        private readonly IPaymentFacade _paymentFacade;

        public EventsController(IEventFacade eventFacade, IPaymentFacade paymentFacade)
        {
            _eventFacade = eventFacade;
            _paymentFacade = paymentFacade;
        }

        [HttpGet]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Events not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Events retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListDTO>>> Get()
        {
            var events = await _eventFacade.GetAll();
            return Ok(events);
        }

        [HttpGet("costs")]
        [Authorize(Policy = Policy.Finance)]
        [SwaggerResponse(StatusCodes.Status200OK, "Events retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithTotalCostsDTO>>> GetCosts()
        {
            var events = await _eventFacade.GetAllWithTotalCosts();
            return Ok(events);
        }

        [HttpGet("user")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One event retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithUserEntryDTO>>> GetWithEntryInfo()
        {
            var userId = User.Identity.GetUserId();
            var events = await _eventFacade.GetAllWithUserEntry(userId);
            if (events == null)
                return NotFound();
            return Ok(events);
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One event retrieved.")]
        public async Task<ActionResult<EventDTO>> Get(int id)
        {
            var e = await _eventFacade.GetById(id);

            if (e == null)
                return NotFound();
            return Ok(e);
        }

        [HttpPost]
        [Authorize(Policy = Policy.Events)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided event.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event added.")]
        public async Task<ActionResult> Post([FromBody] EventDTO e)
        {
            if (e == null)
                return BadRequest();

            e.Entries = EntriesExport.OK;
            await _eventFacade.Create(e);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = Policy.Events)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided event.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event updated.")]
        public async Task<ActionResult> Put([FromBody] EventDTO e)
        {
            if (e == null)
                return BadRequest();

            await _eventFacade.Update(e);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Policy.Events)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event deleted.")]
        public async Task<ActionResult> Delete(int id)
        {
            var e = await _eventFacade.GetById(id);

            if (e == null)
                return NotFound();
            var payments = await _paymentFacade.GetAllByEventId(id);
            foreach (var p in payments)
                await _paymentFacade.Delete(p.Id);
            await _eventFacade.Delete(id);
            return Ok();
        }
    }
}