using ClubIS.CoreLayer.DTOs;
using ClubIS.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClubIS.Web.Services.Implementations
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;

        public AuthorizeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Login(LoginParametersDTO loginParameters)
        {
            //var stringContent = new StringContent(JsonSerializer.Serialize(loginParameters), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsJsonAsync("Authorize/login", loginParameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("Authorize/logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterParametersDTO registerParameters)
        {
            //var stringContent = new StringContent(JsonSerializer.Serialize(registerParameters), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsJsonAsync("Authorize/register", registerParameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<UserInfoDTO> GetUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<UserInfoDTO>("Authorize/user-info");
            return result;
        }

        public async Task ChangeLogin(ChangeLoginDTO parameters)
        {
            var result = await _httpClient.PutAsJsonAsync("Authorize/login", parameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task ChangePassword(ChangePasswordDTO parameters)
        {
            var result = await _httpClient.PutAsJsonAsync("Authorize/password", parameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<UserRolesDTO> GetUserRolesById(int userId)
        {
            return await _httpClient.GetFromJsonAsync<UserRolesDTO>($"Authorize/roles/{userId}");
        }

        public async Task ChangeUserRoles(UserRolesDTO userRoles)
        {
            var result = await _httpClient.PutAsJsonAsync("Authorize/roles", userRoles);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<string> GetUserNameById(int userId)
        {
            return await _httpClient.GetFromJsonAsync<string>($"Authorize/username/{userId}");
        }
    }
}
