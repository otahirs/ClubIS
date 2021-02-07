using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using ClubIS.IdentityStore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<IdentityStoreUser> _userManager;
        private readonly SignInManager<IdentityStoreUser> _signInManager;
        private readonly IUserFacade _userFacade;

        public AuthorizeController(UserManager<IdentityStoreUser> userManager, SignInManager<IdentityStoreUser> signInManager, IUserFacade userFacade)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userFacade = userFacade;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginParametersDTO parameters)
        {
            IdentityStoreUser user = await _userManager.FindByNameAsync(parameters.UserName);
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            Microsoft.AspNetCore.Identity.SignInResult singInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!singInResult.Succeeded)
            {
                return BadRequest("Invalid password");
            }

            await _signInManager.SignInAsync(user, parameters.RememberMe);

            return Ok();
        }


        [HttpPost("register")]
        [Authorize(Policy = Policy.Users)]
        public async Task<IActionResult> Register(RegisterParametersDTO parameters)
        {
            IdentityStoreUser userIdentity = new IdentityStoreUser
            {
                UserName = parameters.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(userIdentity, parameters.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            IdentityStoreUser identityUser = await _userManager.FindByNameAsync(userIdentity.UserName);
            UserDTO user = new UserDTO()
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
        public async Task<UserInfoDTO> UserInfo()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return new UserInfoDTO();
            }
            return await BuildUserInfo();
        }

        private async Task<UserInfoDTO> BuildUserInfo()
        {
            UserDTO user = await _userFacade.GetById(User.Identity.GetUserId());
            return new UserInfoDTO
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = user.Firstname + " " + user.Surname,
                UserId = user.Id,
                ExposedClaims = User.Claims
                    //Optionally: filter the claims you want to expose to the client
                    //.Where(c => c.Type == "test-claim")
                    .GroupBy(c => c.Type)
                    .ToDictionary(grp => grp.Key, grp => grp.Last().Value)
                //.ToDictionary(c => c.Type, c => c.Value) can lead to errors if claims are altered
            };
        }

        [HttpPut("login")]
        [Authorize]
        public async Task<IActionResult> ChangeLogin(ChangeLoginDTO parameters)
        {
            if (User.Identity.GetUserId() != parameters.EditedUserId &&
                !User.IsInRole(Role.Users) &&
                !User.IsInRole(Role.Admin))
            {
                return Unauthorized();
            }
            IdentityStoreUser user = await _userManager.GetUserAsync(User);
            if (!await _userManager.CheckPasswordAsync(user, parameters.AprovalPassword))
            {
                return BadRequest("Invalid password");
            }
            IdentityStoreUser editedUser = await GetUserIdentityById(parameters.EditedUserId);
            IdentityResult result = await _userManager.SetUserNameAsync(editedUser, parameters.NewUserName);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            return Ok();
        }

        [HttpPut("password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO parameters)
        {
            if (User.Identity.GetUserId() != parameters.EditedUserId &&
               !User.IsInRole(Role.Users) &&
               !User.IsInRole(Role.Admin))
            {
                return Unauthorized();
            }
            IdentityStoreUser user = await _userManager.GetUserAsync(User);
            if (!await _userManager.CheckPasswordAsync(user, parameters.OldPassword))
            {
                return BadRequest("Invalid password");
            }
            IdentityStoreUser editedUser = await GetUserIdentityById(parameters.EditedUserId);
            IdentityResult result = await _userManager.ChangePasswordAsync(editedUser, parameters.OldPassword, parameters.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            return Ok();
        }

        [HttpGet("roles/{userId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User roles retrieved.")]
        public async Task<ActionResult<UserRolesDTO>> Get(int userId)
        {
            IdentityStoreUser user = await GetUserIdentityById(userId);
            if (user == null)
            {
                return NotFound();
            }
            IList<string> rolesList = await _userManager.GetRolesAsync(user);
            UserRolesDTO roles = new UserRolesDTO() { UserId = userId, Roles = rolesList };
            return Ok(roles);
        }

        private Task<IdentityStoreUser> GetUserIdentityById(int userId)
        {
            return _userManager.FindByIdAsync(userId.ToString());
        }

        [HttpGet("username/{userId}")]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Username retrieved.")]
        public async Task<ActionResult<string>> GetUserNameById(int userId)
        {
            if (User.Identity.GetUserId() != userId &&
               !User.IsInRole(Role.Users) &&
               !User.IsInRole(Role.Admin))
            {
                return Unauthorized();
            }

            IdentityStoreUser user = await GetUserIdentityById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return new JsonResult(user.UserName);
        }

        [HttpPut("roles")]
        [Authorize(Policy = Policy.Users)]
        public async Task<IActionResult> ChangeUserRoles(UserRolesDTO userRoles)
        {
            IdentityStoreUser user = await GetUserIdentityById(userRoles.UserId);
            if (user == null)
            {
                return NotFound();
            }
            IList<string> oldRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, oldRoles);
            IdentityResult result = await _userManager.AddToRolesAsync(user, userRoles.Roles);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            return Ok();
        }
    }
}
