using ClubIS.CoreLayer.DTOs;
using ClubIS.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClubIS.Web.Services.Implementations
{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private UserInfoDTO _userInfoCache;
        private readonly IAuthorizeApi _authorizeApi;

        public IdentityAuthenticationStateProvider(IAuthorizeApi authorizeApi)
        {
            this._authorizeApi = authorizeApi;
        }

        public async Task Login(LoginParametersDTO loginParameters)
        {
            await _authorizeApi.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Register(RegisterParametersDTO registerParameters)
        {
            await _authorizeApi.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await _authorizeApi.Logout();
            _userInfoCache = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private async Task<UserInfoDTO> GetUserInfo()
        {
            if (_userInfoCache != null && _userInfoCache.IsAuthenticated) return _userInfoCache;
            _userInfoCache = await _authorizeApi.GetUserInfo();
            return _userInfoCache;
        }

        public async Task<int> GetUserId()
        {
            var userInfo = await GetUserInfo();
            return userInfo.UserId;
        }

        public async Task<string> GetUserName()
        {
            var userInfo = await GetUserInfo();
            return userInfo.UserName;
        }

        public async Task<UserRolesDTO> GetUserRolesById(int userId)
        {
            return await _authorizeApi.GetUserRolesById(userId);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetUserInfo();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }.Concat(userInfo.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task ChangeLogin(ChangeLoginDTO parameters)
        {
            await _authorizeApi.ChangeLogin(parameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task ChangePassword(ChangePasswordDTO parameters)
        {
            await _authorizeApi.ChangePassword(parameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task ChangeUserRoles(UserRolesDTO userRoles)
        {
            await _authorizeApi.ChangeUserRoles(userRoles);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
