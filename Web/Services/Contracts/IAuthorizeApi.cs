using ClubIS.CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubIS.Web.Services.Contracts
{
    public interface IAuthorizeApi
    {
        Task Login(LoginParametersDTO loginParameters);
        Task Register(RegisterParametersDTO registerParameters);
        Task Logout();
        Task<UserInfoDTO> GetUserInfo();
    }
}
