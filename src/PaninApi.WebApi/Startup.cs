using AutoMapper;
using CoRDependencyInjection.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Exceptions;
using PaninApi.Abstractions.Services;
using PaninApi.WebApi.Chains;
using PaninApi.WebApi.Consts;
using PaninApi.WebApi.Filters;
using PaninApi.WebApi.Handlers.User;
using PaninApi.WebApi.Services;
using PaninApi.WebApi.Validators;
using Serilog;

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
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();

            _configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PaninApiDbContext>(builder =>
                builder.UseNpgsql(_configuration.GetConnectionString(DbContextConsts.DefaultConnectionString)));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(_configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(options => options.Filters.Add<ProblemExceptionFilter>()).AddFluentValidation();

            #region Services

            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICoffeeShopService, CoffeeShopService>();

            #endregion

            services.AddChain<IUserChain>()
                .WithHandler<StudentHandler>()
                .WithHandler<BarmanHandler>().BuildChain();

            #region Validators

            services.AddTransient<IValidator<InputStudentClassDto>, InputStudentClassDtoValidator>();

            #endregion

            #region Logging

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog(Log.Logger);
            });

            #endregion

            services.AddConnections();
            services.AddProblemDetails();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseProblemDetails();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}