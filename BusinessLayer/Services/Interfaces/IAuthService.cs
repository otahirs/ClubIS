using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateIdentity(string userName, string password);
        Task<UserIdentity> GetIdentity(string userName);
        Task<UserIdentity> GetIdentity(int userId);
        Task<UserRolesDTO> GetRoles(UserIdentity userIdentity);
        Task<IdentityResult> ChangeRoles(UserRolesDTO newRoles);
        Task<SignInResult> SignIn(LoginParametersDTO parameters);
        Task Logout();
        Task<bool> CheckPassword(UserIdentity userIdentity, string password);
        Task<IdentityResult> ChangeLogin(UserIdentity userIdentity, string newUsername);
        Task<IdentityResult> ChangePassword(UserIdentity userIdentity, string newPassword);
        Task<UserRolesDTO> GetRoles(int userId);
    }
}
