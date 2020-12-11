using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
