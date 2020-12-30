using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using ClubIS.IdentityStore;
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
        private IEventFacade _eventFacade;
        private IPaymentFacade _paymentFacade;

        public EventsController(IEventFacade eventFacade, IPaymentFacade paymentFacade)
        {
            _eventFacade = eventFacade;
            _paymentFacade = paymentFacade;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Events not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Events retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListDTO>>> Get()
        {
            var events = await _eventFacade.GetAll();
            return Ok(events);
        }

        [HttpGet("costs")]
        [SwaggerResponse(StatusCodes.Status200OK, "Events retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithTotalCostsDTO>>> GetCosts()
        {
            var events = await _eventFacade.GetAllWithTotalCosts();
            return Ok(events);
        }

        [HttpGet("user")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One event retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithUserEntryDTO>>> GetWithEntryInfo()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            var userId = User.Identity.GetUserId();
            var events = await _eventFacade.GetAllWithUserEntry(userId);
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One event retrieved.")]
        public async Task<ActionResult<EventEditDTO>> Get([Range(1, int.MaxValue)] int id)
        {
            var e = await _eventFacade.GetById(id);

            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided event.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event added.")]
        public async Task<ActionResult> Post([FromBody] EventEditDTO e)
        {
            if (e == null)
                return BadRequest();

            e.Entries = EntriesExport.OK;
            await _eventFacade.Create(e);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided event.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event updated.")]
        public async Task<ActionResult> Put([FromBody] EventEditDTO e)
        {
            if (e == null)
                return BadRequest();

            await _eventFacade.Update(e);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event deleted.")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)] int id)
        {
            var e = await _eventFacade.GetById(id);

            if (e == null)
            {
                return NotFound();
            }
            var payments = await _paymentFacade.GetAllByEventID(id);
            foreach (var p in payments)
            {
                await _paymentFacade.Delete(p.Id);
            }
            await _eventFacade.Delete(id);
            return Ok();
        }
    }
}
