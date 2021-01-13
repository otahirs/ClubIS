using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EntriesController : ControllerBase
    {
        private IEntryFacade _entryFacade;
        private IEventFacade _eventFacade;

        public EntriesController(IEntryFacade entryFacade, IEventFacade eventFacade)
        {
            _entryFacade = entryFacade;
            _eventFacade = eventFacade;
        }

        [HttpGet("event/{eventId}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entries retrieved.")]
        public async Task<ActionResult<IEnumerable<EventEntryListDTO>>> GetByEventId(int eventId)
        {
            var entries = await _entryFacade.GetAllByEventId(eventId);
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }


        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One entry retrieved.")]
        public async Task<ActionResult<EventEntryListDTO>> Get(int id)
        {
            var entry = await _entryFacade.GetById(id);

            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided entry.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry added.")]
        public async Task<ActionResult> Post([FromBody] EventEntryEditDTO entry)
        {
            if (entry == null)
                return BadRequest();

            await _entryFacade.Create(entry);

            var e = await _eventFacade.GetById(entry.EventId);
            if (e.Entries != EntriesExport.Changed)
            {
                e.Entries = EntriesExport.Changed;
                await _eventFacade.Update(e);
            }

            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided entry.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry updated.")]
        public async Task<ActionResult> Put([FromBody] EventEntryEditDTO entry)
        {
            if (entry == null)
                return BadRequest();

            await _entryFacade.Update(entry);

            var e = await _eventFacade.GetById(entry.EventId);
            if (e.Entries != EntriesExport.Changed)
            {
                e.Entries = EntriesExport.Changed;
                await _eventFacade.Update(e);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry deleted.")]
        public async Task<ActionResult> Delete(int id)
        {
            var entry = await _entryFacade.GetById(id);

            if (entry == null)
            {
                return NotFound();
            }
            await _entryFacade.Delete(id);
            return Ok();
        }
    }
}
