using AutoMapper;
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

namespace ClubIS.BusinessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork, UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<SignInResult> SignIn(LoginParametersDTO parameters)
        {
            return _signInManager.PasswordSignInAsync(parameters.UserName, parameters.Password, parameters.RememberMe, false);
        }

        public Task Logout()
        {
            return _signInManager.SignOutAsync();
        }

        public Task<IdentityResult> CreateIdentity(string userName, string password)
        {
            UserIdentity userIdentity = new UserIdentity() { UserName = userName };
            var result = _userManager.CreateAsync(userIdentity, password);
            _unitOfWork.Save();
            return result;
        }
        public Task<UserIdentity> GetIdentity(string userName)
        {
            return _userManager.FindByNameAsync(userName);
        }

        public Task<UserIdentity> GetIdentity(int userId)
        {
            return _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<UserRolesDTO> GetRoles(UserIdentity userIdentity)
        {
            IList<string> rolesList = await _userManager.GetRolesAsync(userIdentity);
            return new UserRolesDTO() { UserId = userIdentity.Id, Roles = rolesList };
        }

        public async Task<IdentityResult> ChangeRoles(UserRolesDTO newRoles)
        {
            UserIdentity userIdentity = await GetIdentity(newRoles.UserId);
            IList<string> oldRoles = await _userManager.GetRolesAsync(userIdentity);
            await _userManager.RemoveFromRolesAsync(userIdentity, oldRoles);
            return await _userManager.AddToRolesAsync(userIdentity, newRoles.Roles);
        }

        public Task<bool> CheckPassword(UserIdentity userIdentity, string password)
        {
            return _userManager.CheckPasswordAsync(userIdentity, password);
        }

        public Task<IdentityResult> ChangeLogin(UserIdentity userIdentity, string newUsername)
        {
            return _userManager.SetUserNameAsync(userIdentity, newUsername);
        }

        public async Task<IdentityResult> ChangePassword(UserIdentity userIdentity, string newPassword)
        {
            foreach (var validator in _userManager.PasswordValidators)
            {
                var result = await validator.ValidateAsync(_userManager, null, newPassword);
                if (!result.Succeeded)
                {
                    return result;
                }
            }
            await _userManager.RemovePasswordAsync(userIdentity);
            return await _userManager.AddPasswordAsync(userIdentity, newPassword);
        }
    }
}
