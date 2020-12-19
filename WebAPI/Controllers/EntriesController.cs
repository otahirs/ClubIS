using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using clubIS.BusinessLayer.Facades.Interfaces;
using clubIS.CoreLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace clubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EntriesController : ControllerBase
    {
        private IEntryFacade _entryFacade;

        public EntriesController(IEntryFacade entryFacade)
        {
            _entryFacade = entryFacade;
        }

        [HttpGet("event/{eventId}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entries retrieved.")]
        public async Task<ActionResult<IEnumerable<EventEntryListDTO>>> GetByEventId([Range(1, int.MaxValue)] int id)
        {
            var entries = await _entryFacade.GetAllByEventId(id);
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One entry retrieved.")]
        public async Task<ActionResult<EventEntryEditDTO>> Get([Range(1, int.MaxValue)] int id)
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
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry deleted.")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)] int id)
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
