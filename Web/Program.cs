using ClubIS.CoreLayer.Enums;
using ClubIS.Web.Services.Contracts;
using ClubIS.Web.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClubIS.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy(Policy.News, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.News)));
                options.AddPolicy(Policy.Entries, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Entries)));
                options.AddPolicy(Policy.Events, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Events)));
                options.AddPolicy(Policy.Users, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Users)));
                options.AddPolicy(Policy.Finance, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Finance)));
            });
            builder.Services.AddScoped<Searching>();
            builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthorizeApi, AuthorizeApi>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/v1/") });
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
