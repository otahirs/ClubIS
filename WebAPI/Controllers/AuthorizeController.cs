using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;
using ClubIS.CoreLayer;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ClubIS.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        
        private readonly IUserFacade _userFacade;
        private readonly IAuthFacade _authFacade;

        public AuthorizeController(IUserFacade userFacade, IAuthFacade authFacade)
        {
            _userFacade = userFacade;
            _authFacade = authFacade;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginParametersDTO parameters)
        {
            SignInResult singInResult = await _authFacade.SignIn(parameters);
            if (!singInResult.Succeeded)
            {
                return BadRequest("Invalid credentials");
            }
            return Ok();
        }

        [HttpPost("register")]
        [Authorize(Policy = Policy.Users)]
        public async Task<IActionResult> Register(RegisterParametersDTO parameters)
        {
            if(parameters.Password != parameters.PasswordConfirm)
            {
                return BadRequest("Passwords do not match");
            }
            var result = await _authFacade.CreateNewUser(parameters);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }
            return Ok();
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authFacade.Logout();
            return Ok();
        }

        [HttpGet("user-info")]
        public async Task<UserInfoDTO> UserInfo()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return new UserInfoDTO();
            }
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
            if (!await _authFacade.CheckPassword(User.Identity.GetUserId(), parameters.AprovalPassword))
            {
                return BadRequest("Invalid password");
            }

            IdentityResult result = await _authFacade.ChangeLogin(parameters.EditedUserId, parameters.NewUserName);
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

            if (!await _authFacade.CheckPassword(User.Identity.GetUserId(), parameters.OldPassword))
            {
                return BadRequest("Invalid password");
            }

            IdentityResult result = await _authFacade.ChangePassword(parameters.EditedUserId, parameters.NewPassword);
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
            if (await _authFacade.UserExist(userId))
            {
                UserRolesDTO roles = await _authFacade.GetRoles(userId);
                return Ok(roles);
            }
            return NotFound();
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
            
            if (await _authFacade.UserExist(userId))
            {
                return new JsonResult(await _authFacade.GetUserName(userId));
            }
            return NotFound();
            
        }

        [HttpPut("roles")]
        [Authorize(Policy = Policy.Users)]
        public async Task<IActionResult> ChangeUserRoles(UserRolesDTO userRoles)
        {
            if (await _authFacade.UserExist(userRoles.UserId))
            {
                IdentityResult result = await _authFacade.ChangeRoles(userRoles);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }
            return NotFound();
        }
    }
}
