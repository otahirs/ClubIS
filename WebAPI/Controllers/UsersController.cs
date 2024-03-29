﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUserFacade _userFacade;

        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Users not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Users retrieved.")]
        public async Task<ActionResult<IEnumerable<UserListDTO>>> Get()
        {
            var users = await _userFacade.GetAll();
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet("entriesSupervisor")]
        [Authorize(Policy = Policy.Users)]
        [SwaggerResponse(StatusCodes.Status200OK, "Users retrieved.")]
        public async Task<ActionResult<IEnumerable<UserEntriesSupervisedListDTO>>> GetEntriesSupervisors()
        {
            var users = await _userFacade.GetAllEntriesSupervisors();
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet("can-edit-entries/{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EntryUserListDTO>>> GetEntryUserList(int id)
        {
            if (User.Identity.GetUserId() != id && !User.IsInRole(Role.Users) && !User.IsInRole(Role.Admin))
                return Unauthorized();
            var users = await _userFacade.GetEntryUserList(id);
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "One user retrieved.")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _userFacade.GetById(id);

            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut]
        [Authorize(Policy = Policy.Users)]
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
        [Authorize]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided user.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User updated.")]
        public async Task<ActionResult> Put([FromBody] MemberUserEditDTO user)
        {
            if (User.Identity.GetUserId() != user.Id && !User.IsInRole(Role.Users) && !User.IsInRole(Role.Admin))
                return Unauthorized();

            await _userFacade.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Policy.Users)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User deleted.")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userFacade.GetById(id);

            if (user == null)
                return NotFound();
            await _userFacade.Delete(id);
            return Ok();
        }


        [HttpGet("supervision/{id}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Supervisions not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Supervisions retrieved.")]
        public async Task<ActionResult<UserSupervisionsDTO>> UserSupervisions(int id)
        {
            if (User.Identity.GetUserId() != id && !User.IsInRole(Role.Users) && !User.IsInRole(Role.Admin))
                return Unauthorized();

            var userSupervisions = await _userFacade.GetUserSupervisions(id);
            if (userSupervisions == null)
                return NotFound();
            return Ok(userSupervisions);
        }

        [HttpPut("supervision")]
        [Authorize(Policy = Policy.Users)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Something wrong with the provided Supervisions.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Supervisions updated.")]
        public async Task<ActionResult> Put([FromBody] UserSupervisionsDTO user)
        {
            if (user == null)
                return BadRequest();

            await _userFacade.UpdateSupervisions(user);
            return Ok();
        }

        [HttpGet("permissions")]
        [Authorize(Policy = Policy.Users)]
        public async Task<ActionResult<IEnumerable<UserPermListDTO>>> GetAllWithPermissions()
        {
            var users = await _userFacade.GetAllWithPermissions();
            if (users == null)
                return NotFound();
            return Ok(users);
        }
    }
}