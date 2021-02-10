using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using ClubIS.IdentityStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly IEntryFacade _entryFacade;
        private readonly IEventFacade _eventFacade;

        public EntriesController(IEntryFacade entryFacade, IEventFacade eventFacade)
        {
            _entryFacade = entryFacade;
            _eventFacade = eventFacade;
        }

        [HttpGet("event/{eventId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entries retrieved.")]
        public async Task<ActionResult<IEnumerable<EventEntryDTO>>> GetByEventId(int eventId)
        {
            IEnumerable<EventEntryDTO> entries = await _entryFacade.GetAllByEventId(eventId);
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }


        [HttpGet("{id}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One entry retrieved.")]
        public async Task<ActionResult<EventEntryDTO>> Get(int id)
        {
            EventEntryDTO entry = await _entryFacade.GetById(id);

            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided entry.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry added.")]
        public async Task<ActionResult> Post([FromBody] EventEntryDTO entry)
        {
            if (User.Identity.GetUserId() != entry.UserId &&
                !User.IsInRole(Role.Entries) &&
                !User.IsInRole(Role.Admin))
            {
                return Unauthorized();
            }

            if (entry == null)
            {
                return BadRequest();
            }

            await _entryFacade.Create(entry);

            EventDTO e = await _eventFacade.GetById(entry.EventId);
            if (e.Entries != EntriesExport.Changed)
            {
                e.Entries = EntriesExport.Changed;
                await _eventFacade.Update(e);
            }

            return Ok();
        }

        [HttpPut]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided entry.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry updated.")]
        public async Task<ActionResult> Put([FromBody] EventEntryDTO entry)
        {
            if (User.Identity.GetUserId() != entry.UserId &&
                !User.IsInRole(Role.Entries) &&
                !User.IsInRole(Role.Admin))
            {
                return Unauthorized();
            }

            if (entry == null)
            {
                return BadRequest();
            }

            await _entryFacade.Update(entry);

            EventDTO e = await _eventFacade.GetById(entry.EventId);
            if (e.Entries != EntriesExport.Changed)
            {
                e.Entries = EntriesExport.Changed;
                await _eventFacade.Update(e);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry deleted.")]
        public async Task<ActionResult> Delete(int id)
        {
            EventEntryDTO entry = await _entryFacade.GetById(id);
            if (entry == null)
            {
                return NotFound();
            }
            if (User.Identity.GetUserId() != entry.UserId &&
                !User.IsInRole(Role.Entries) &&
                !User.IsInRole(Role.Admin))
            {
                return Unauthorized();
            }
            await _entryFacade.Delete(id);
            return Ok();
        }
    }
}
