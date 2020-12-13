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
    public class NewsController : ControllerBase
    {
        private INewsFacade _newsFacade;

        public NewsController(INewsFacade newsFacade)
        {
            _newsFacade = newsFacade;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "News not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "News retrieved.")]
        public async Task<ActionResult<IEnumerable<NewsListDTO>>> Get()
        {
            var entries = await _newsFacade.GetAll();
            if (entries == null)
            {
                return NotFound();
            }
            return Ok(entries);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "News not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One news retrieved.")]
        public async Task<ActionResult<NewsEditDTO>> Get([Range(1, int.MaxValue)] int id)
        {
            var news = await _newsFacade.GetById(id);

            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided news.")]
        [SwaggerResponse(StatusCodes.Status200OK, "News added.")]
        public async Task<ActionResult> Post([FromBody] NewsEditDTO news)
        {
            if (news == null)
                return BadRequest();

            await _newsFacade.Create(news);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided news.")]
        [SwaggerResponse(StatusCodes.Status200OK, "News updated.")]
        public async Task<ActionResult> Put([FromBody] NewsEditDTO news)
        {
            if (news == null)
                return BadRequest();

            await _newsFacade.Update(news);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "News not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "News deleted.")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)] int id)
        {
            var news = await _newsFacade.GetById(id);

            if (news == null)
            {
                return NotFound();
            }
            await _newsFacade.Delete(id);
            return Ok();
        }
    }
}
