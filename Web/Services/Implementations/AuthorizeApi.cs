using ClubIS.CoreLayer.DTOs;
using ClubIS.Web.Services.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Json;
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
            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("Authorize/login", loginParameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }

            result.EnsureSuccessStatusCode();
        }

        public async Task Logout()
        {
            HttpResponseMessage result = await _httpClient.PostAsync("Authorize/logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterParametersDTO registerParameters)
        {
            //var stringContent = new StringContent(JsonSerializer.Serialize(registerParameters), Encoding.UTF8, "application/json");
            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("Authorize/register", registerParameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }

            result.EnsureSuccessStatusCode();
        }

        public async Task<UserInfoDTO> GetUserInfo()
        {
            UserInfoDTO result = await _httpClient.GetFromJsonAsync<UserInfoDTO>("Authorize/user-info");
            return result;
        }

        public async Task ChangeLogin(ChangeLoginDTO parameters)
        {
            HttpResponseMessage result = await _httpClient.PutAsJsonAsync("Authorize/login", parameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }

            result.EnsureSuccessStatusCode();
        }

        public async Task ChangePassword(ChangePasswordDTO parameters)
        {
            HttpResponseMessage result = await _httpClient.PutAsJsonAsync("Authorize/password", parameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }

            result.EnsureSuccessStatusCode();
        }

        public async Task<UserRolesDTO> GetUserRolesById(int userId)
        {
            return await _httpClient.GetFromJsonAsync<UserRolesDTO>($"Authorize/roles/{userId}");
        }

        public async Task ChangeUserRoles(UserRolesDTO userRoles)
        {
            HttpResponseMessage result = await _httpClient.PutAsJsonAsync("Authorize/roles", userRoles);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }

            result.EnsureSuccessStatusCode();
        }

        public async Task<string> GetUserNameById(int userId)
        {
            return await _httpClient.GetFromJsonAsync<string>($"Authorize/username/{userId}");
        }
    }
}
