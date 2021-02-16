using System;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IAuthFacade : IDisposable
    {
        Task<SignInResult> SignIn(LoginParametersDTO parameters);
        Task<IdentityResult> CreateNewUser(RegisterParametersDTO parameters);
        Task Logout();
        Task<UserRolesDTO> GetRoles(int userId);
        Task<bool> UserExist(int userId);
        Task<IdentityResult> ChangeRoles(UserRolesDTO userRoles);
        Task<string> GetUserName(int userId);
        Task<bool> CheckPassword(int userId, string aprovalPassword);
        Task<IdentityResult> ChangeLogin(int editedUserId, string newUserName);
        Task<IdentityResult> ChangePassword(int editedUserId, string newUserName);
    }
}