using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.Web.Services.Contracts
{
    public interface IAuthorizeApi
    {
        Task Login(LoginParametersDTO loginParameters);
        Task Register(RegisterParametersDTO registerParameters);
        Task Logout();
        Task<UserInfoDTO> GetUserInfo();
        Task<string> GetUserNameById(int userId);
        Task ChangeLogin(ChangeLoginDTO parameters);
        Task ChangePassword(ChangePasswordDTO parameters);
        Task<UserRolesDTO> GetUserRolesById(int userId);
        Task ChangeUserRoles(UserRolesDTO userRoles);
    }
}