using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.Facades.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace clubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EntryController : ControllerBase
    {
        private IEntryFacade _facade;

        public EntryController(IEntryFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("event/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entries retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithUserEntryDTO>>> GetByEventId([Range(1, int.MaxValue)] int id)
        {
            var entries = await _facade.GetAllByEventId(id);
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One entry retrieved.")]
        public async Task<ActionResult<EventEditDTO>> Get([Range(1, int.MaxValue)] int id)
        {
            var entry = await _facade.GetById(id);

            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided entry.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry added.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> Post([FromBody] EventEntryEditDTO entry)
        {
            if (entry == null)
                return BadRequest();

            await _facade.Create(entry);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided entry.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry updated.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> Put([FromBody] EventEntryEditDTO entry)
        {
            if (entry == null)
                return BadRequest();

            await _facade.Update(entry);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Entry not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entry deleted.")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)] int id)
        {
            var entry = await _facade.GetById(id);

            if (entry == null)
            {
                return NotFound();
            }
            await _facade.Delete(id);
            return Ok();
        }
    }
}
