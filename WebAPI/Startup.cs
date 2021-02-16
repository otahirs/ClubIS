using System;
using System.Threading.Tasks;
using ClubIS.BusinessLayer;
using ClubIS.BusinessLayer.Facades;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using ClubIS.DataAccessLayer;
using ClubIS.DataAccessLayer.Repositories;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClubIS.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSwaggerGen();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("PostgresDb"));
                options.EnableSensitiveDataLogging();
            });

            services.AddIdentity<UserIdentity, IdentityRole<int>>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                //options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = false;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<IEntryFacade, EntryFacade>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventFacade, EventFacade>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsFacade, NewsFacade>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentFacade, PaymentFacade>();
            services.AddScoped<IMemberFeeRepository, MemberFeeRepository>();
            services.AddScoped<IMemberFeeService, MemberFeeService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthFacade, AuthFacade>();
            services.AddControllers();

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'V";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.News, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.News)));
                options.AddPolicy(Policy.Entries, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Entries)));
                options.AddPolicy(Policy.Events, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Events)));
                options.AddPolicy(Policy.Users, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Users)));
                options.AddPolicy(Policy.Finance, policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(Role.Admin) || ctx.User.IsInRole(Role.Finance)));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider, DataContext dataContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                for (var i = provider.ApiVersionDescriptions.Count - 1; i >= 0; i--)
                {
                    var description = provider.ApiVersionDescriptions[i];
                    c.SwaggerEndpoint($"{description.GroupName}/swagger.json", $"Demo ClubIS API {description.GroupName}");
                }
            });
        }
    }
}