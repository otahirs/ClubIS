using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClubIS.WebAPI.Controllers
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

        [HttpGet("entriesSupervisor/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Supervisors retrieved.")]
        public async Task<ActionResult<UserEntryListDTO>> GetEntriesSupervisors(int id)
        {
            var users = await _userFacade.GetAllEntriesSupervisorsById(id);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One user retrieved.")]
        public async Task<ActionResult<UserDTO>> Get(int id)
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
        public async Task<ActionResult> Post([FromBody] UserDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.Create(user);
            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User updated.")]
        public async Task<ActionResult> Put([FromBody] UserDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.Update(user);
            return Ok();
        }

        [HttpPut("member-edit")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User updated.")]
        public async Task<ActionResult> Put([FromBody] MemberUserEditDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User deleted.")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userFacade.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            await _userFacade.Delete(id);
            return Ok();
        }


        [HttpGet("supervision/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Member fee types not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Member fee types retrieved.")]
        public async Task<ActionResult<UserSupervisionsDTO>> UserSupervisions(int id)
        {

            var userSupervisions = await _userFacade.GetUserSupervisions(id);
            if (userSupervisions == null)
            {
                return NotFound();
            }
            return Ok(userSupervisions);
        }

        [HttpPut("supervision")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User updated.")]
        public async Task<ActionResult> Put([FromBody] UserSupervisionsDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.UpdateSupervisions(user);
            return Ok();
        }
    }
}
