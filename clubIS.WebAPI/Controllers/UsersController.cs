using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class UsersController : ControllerBase
    {
        private IUserFacade _userFacade;

        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Users not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Users retrieved.")]
        public async Task<ActionResult<IEnumerable<UserListDTO>>> Get()
        {
            var users = await _userFacade.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("entriesSupervisor")]
        [SwaggerResponse(StatusCodes.Status200OK, "Users retrieved.")]
        public async Task<ActionResult<IEnumerable<UserEntriesSupervisedListDTO>>> GetEntriesSupervisors()
        {
            var users = await _userFacade.GetAllEntriesSupervisors();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One user retrieved.")]
        public async Task<ActionResult<UserDetailDTO>> Get([Range(1, int.MaxValue)] int id)
        {
            var user = await _userFacade.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User added.")]
        public async Task<ActionResult> Post([FromBody] UserEditDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.Create(user);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User updated.")]
        public async Task<ActionResult> Put([FromBody] UserEditDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.Update(user);
            return Ok();
        }

        [HttpPut("login")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User login updated.")]
        public async Task<ActionResult> PutLogin([FromBody] UserCredentialsEditDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.UpdateLogin(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User deleted.")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)] int id)
        {
            var user = await _userFacade.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            await _userFacade.Delete(id);
            return Ok();
        }

    }
}
