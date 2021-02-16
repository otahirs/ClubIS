using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;
using Microsoft.AspNetCore.Identity;

namespace ClubIS.BusinessLayer.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public AuthFacade(IUnitOfWork unitOfWork, IUserService userService, IAuthService authService)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<SignInResult> SignIn(LoginParametersDTO parameters)
        {
            return _authService.SignIn(parameters);
        }

        public async Task<IdentityResult> CreateNewUser(RegisterParametersDTO parameters)
        {
            var result = await _authService.CreateIdentity(parameters.UserName, parameters.Password);
            if (result.Succeeded)
            {
                var identityUser = await _authService.GetIdentity(parameters.UserName);
                var user = new UserDTO
                {
                    Id = identityUser.Id,
                    Firstname = parameters.Firstname,
                    Surname = parameters.Surname,
                    RegistrationNumber = parameters.RegistrationNumber
                };
                await _userService.Create(user);
                await _unitOfWork.Save();
            }

            return result;
        }

        public Task Logout()
        {
            return _authService.Logout();
        }

        public async Task<string> GetUserName(int userId)
        {
            var userIdentity = await _authService.GetIdentity(userId);
            return userIdentity.UserName;
        }

        public async Task<UserRolesDTO> GetRoles(int userId)
        {
            var userIdentity = await _authService.GetIdentity(userId);
            return await _authService.GetRoles(userIdentity);
        }

        public async Task<bool> UserExist(int userId)
        {
            var userIdentity = await _authService.GetIdentity(userId);
            return userIdentity != null;
        }

        public Task<IdentityResult> ChangeRoles(UserRolesDTO userRoles)
        {
            return _authService.ChangeRoles(userRoles);
        }

        public async Task<bool> CheckPassword(int userId, string aprovalPassword)
        {
            var userIdentity = await _authService.GetIdentity(userId);
            return await _authService.CheckPassword(userIdentity, aprovalPassword);
        }

        public async Task<IdentityResult> ChangeLogin(int editedUserId, string newUserName)
        {
            var userIdentity = await _authService.GetIdentity(editedUserId);
            return await _authService.ChangeLogin(userIdentity, newUserName);
        }

        public async Task<IdentityResult> ChangePassword(int editedUserId, string newPassword)
        {
            var userIdentity = await _authService.GetIdentity(editedUserId);
            return await _authService.ChangePassword(userIdentity, newPassword);
        }
    }
}