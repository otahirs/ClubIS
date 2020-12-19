using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clubIS.BusinessLayer.Facades;
using clubIS.BusinessLayer.Facades.Interfaces;
using clubIS.BusinessLayer.Services;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;
using clubIS.DataAccessLayer.Repositories;
using clubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace clubIS.WebAPI
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

            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
                options.EnableSensitiveDataLogging();
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
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

            services.AddMvc(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(new ConsumesAttribute("application/json"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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