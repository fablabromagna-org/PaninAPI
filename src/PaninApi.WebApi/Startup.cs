using AutoMapper;
using CoRDependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using PaninApi.Abstractions.Services;
using PaninApi.WebApi.Chains;
using PaninApi.WebApi.Handlers.User;
using PaninApi.WebApi.Services;

namespace PaninApi.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddConfiguration(configuration)
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(typeof(Startup).Assembly)
                .AddEnvironmentVariables();

            _configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PaninApiDbContext>(builder =>
                builder.UseNpgsql(_configuration.GetConnectionString("default")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(_configuration);

            services.AddAutoMapper(typeof(Startup));
            
            services.AddControllers();

            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<IStudentService, StudentService>();

            services.AddChain<IUserChain>()
                .WithHandler<StudentHandler>()
                .WithHandler<BarmanHandler>().BuildChain();

            services.AddConnections();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}