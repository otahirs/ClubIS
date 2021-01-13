using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Dialog;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using ClubIS.Web.Services.Implementations;
using ClubIS.Web.Services.Contracts;

namespace ClubIS.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("News", policy => policy.RequireAssertion(ctx => ctx.User.IsInRole("admin") || ctx.User.IsInRole("news")));
                options.AddPolicy("Entries", policy => policy.RequireAssertion(ctx => ctx.User.IsInRole("admin") || ctx.User.IsInRole("Entries")));
                options.AddPolicy("Events", policy => policy.RequireAssertion(ctx => ctx.User.IsInRole("admin") || ctx.User.IsInRole("Events")));
                options.AddPolicy("Users", policy => policy.RequireAssertion(ctx => ctx.User.IsInRole("admin") || ctx.User.IsInRole("Users")));
                options.AddPolicy("Finance", policy => policy.RequireAssertion(ctx => ctx.User.IsInRole("admin") || ctx.User.IsInRole("Finace")));
            });
            builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthorizeApi, AuthorizeApi>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/v1/") });
            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudBlazorSnackbar();
            builder.Services.AddMudBlazorResizeListener();

            await builder.Build().RunAsync();
        }
    }
}
