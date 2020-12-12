﻿using System;
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
    public class EventController : ControllerBase
    {
        private IEventFacade _facade;

        public EventController(IEventFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Events retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListDTO>>> Get()
        {
            var events = await _facade.GetAll();
            return Ok(events);
        }

        [HttpGet("status")]
        [SwaggerResponse(StatusCodes.Status200OK, "Events retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithTotalCostsDTO>>> GetStatus()
        {
            var events = await _facade.GetAllWithExportStatus();
            return Ok(events);
        }

        [HttpGet("costs")]
        [SwaggerResponse(StatusCodes.Status200OK, "Events retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithTotalCostsDTO>>> GetCosts()
        {
            var events = await _facade.GetAllWithTotalCosts();
            return Ok(events);
        }

        [HttpGet("entry/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One event retrieved.")]
        public async Task<ActionResult<IEnumerable<EventListWithUserEntryDTO>>> GetByEntryId([Range(1, int.MaxValue)] int id)
        {
            var events = await _facade.GetAllWithUserEntry(id);
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
            var e = await _facade.GetById(id);

            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided event.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event added.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> Post([FromBody] EventEditDTO e)
        {
            if (e == null)
                return BadRequest();

            await _facade.Create(e);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided event.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event updated.")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> Put([FromBody] EventEditDTO e)
        {
            if (e == null)
                return BadRequest();

            await _facade.Update(e);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Event not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event deleted.")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)] int id)
        {
            var e = await _facade.GetById(id);

            if (e == null)
            {
                return NotFound();
            }
            await _facade.Delete(id);
            return Ok();
        }
    }
}
