using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
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
            IdentityResult result = await _authService.CreateIdentity(parameters.UserName, parameters.Password);
            if (result.Succeeded)
            {
                UserIdentity identityUser = await _authService.GetIdentity(parameters.UserName);
                UserDTO user = new UserDTO()
                {
                    Id = identityUser.Id,
                    Firstname = parameters.Firstname,
                    Surname = parameters.Surname,
                    RegistrationNumber = parameters.RegistrationNumber
                };
                await _userService.Create(user);
            }
            return result;
        }

        public Task Logout()
        {
            return _authService.Logout();
        }

        public async Task<string> GetUserName(int userId)
        {
            UserIdentity userIdentity = await _authService.GetIdentity(userId);
            return userIdentity.UserName;
        }
        public async Task<UserRolesDTO> GetRoles(int userId)
        {
            UserIdentity userIdentity = await _authService.GetIdentity(userId);
            return await _authService.GetRoles(userIdentity);
        }

        public async Task<bool> UserExist(int userId)
        {
            UserIdentity userIdentity = await _authService.GetIdentity(userId);
            return userIdentity != null;
        }

        public Task<IdentityResult> ChangeRoles(UserRolesDTO userRoles)
        {
            return _authService.ChangeRoles(userRoles);
        }

        public async Task<bool> CheckPassword(int userId, string aprovalPassword)
        {
            UserIdentity userIdentity = await _authService.GetIdentity(userId);
            return await _authService.CheckPassword(userIdentity, aprovalPassword);
        }

        public async Task<IdentityResult> ChangeLogin(int editedUserId, string newUserName)
        {
            UserIdentity userIdentity = await _authService.GetIdentity(editedUserId);
            return await _authService.ChangeLogin(userIdentity, newUserName);
        }

        public async Task<IdentityResult> ChangePassword(int editedUserId, string newPassword)
        {
            UserIdentity userIdentity = await _authService.GetIdentity(editedUserId);
            return await _authService.ChangePassword(userIdentity, newPassword);
        }
    }
}
