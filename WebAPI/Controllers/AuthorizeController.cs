using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ClubIS.IdentityStore;
using System.Linq;
using System.Security.Claims;
using System;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<IdentityStoreUser> _userManager;
        private readonly SignInManager<IdentityStoreUser> _signInManager;
        private IUserFacade _userFacade;

        public AuthorizeController(UserManager<IdentityStoreUser> userManager, SignInManager<IdentityStoreUser> signInManager, IUserFacade userFacade)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userFacade = userFacade;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginParametersDTO parameters)
        {
            var user = await _userManager.FindByNameAsync(parameters.UserName);
            if (user == null) return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, parameters.RememberMe);

            return Ok();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterParametersDTO parameters)
        {
            var userIdentity = new IdentityStoreUser
            {
                UserName = parameters.UserName
            };
            var result = await _userManager.CreateAsync(userIdentity, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            var identityUser = await _userManager.FindByNameAsync(userIdentity.UserName);
            var user = new UserDTO()
            {
                Id = identityUser.Id,
                Firstname = parameters.Firstname,
                Surname = parameters.Surname,
                RegistrationNumber = parameters.RegistrationNumber
            };

            try
            {
                await _userFacade.Create(user);
            }
            catch (Exception ex)
            {
                // remove Identity if user creation failed
                await _userManager.DeleteAsync(identityUser);
                throw ex;
            }
            
            return await Login(new LoginParametersDTO
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("user-info")]
        public UserInfoDTO UserInfo()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            return BuildUserInfo();
        }

        private UserInfoDTO BuildUserInfo()
        {
            return new UserInfoDTO
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                UserId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : 0,
                ExposedClaims = User.Claims
                    //Optionally: filter the claims you want to expose to the client
                    //.Where(c => c.Type == "test-claim")
                    .ToDictionary(c => c.Type, c => c.Value)
            };
        }

        [HttpPut("login")]
        public async Task<IActionResult> ChangeLogin(ChangeLoginDTO parameters)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            var user = await _userManager.GetUserAsync(User);
            if (!await _userManager.CheckPasswordAsync(user, parameters.AprovalPassword))
            {
                return BadRequest("Invalid password");
            }
            var editedUser = await GetUserIdentityById(parameters.EditedUserId);
            var result = await _userManager.SetUserNameAsync(editedUser, parameters.NewUserName);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);
            return Ok();
        }

        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO parameters)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            var user = await _userManager.GetUserAsync(User);
            if (!await _userManager.CheckPasswordAsync(user, parameters.OldPassword))
            {
                return BadRequest("Invalid password");
            }
            var editedUser = await GetUserIdentityById(parameters.EditedUserId);
            var result = await _userManager.ChangePasswordAsync(editedUser, parameters.OldPassword, parameters.NewPassword);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);
            return Ok();
        }

        [HttpGet("roles/{userId}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User roles retrieved.")]
        public async Task<ActionResult<UserRolesDTO>> Get(int userId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            var user = await GetUserIdentityById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var rolesList = await _userManager.GetRolesAsync(user);
            var roles = new UserRolesDTO() { UserId = userId, Roles = rolesList };
            return Ok(roles);
        }

        private Task<IdentityStoreUser> GetUserIdentityById(int userId)
        {
            return _userManager.FindByIdAsync(userId.ToString());
        } 

        [HttpGet("username/{userId}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Username retrieved.")]
        public async Task<ActionResult<string>> GetUserNameById(int userId)
        {
            var user = await GetUserIdentityById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return new JsonResult(user.UserName);
        }

        [HttpPut("roles")]
        public async Task<IActionResult> ChangeUserRoles(UserRolesDTO userRoles)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            var user = await GetUserIdentityById(userRoles.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var oldRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, oldRoles);
            var result = await _userManager.AddToRolesAsync(user, userRoles.Roles);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);
            return Ok();
        }
    }
}
