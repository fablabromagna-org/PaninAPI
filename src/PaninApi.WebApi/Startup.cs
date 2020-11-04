using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using PaninApi.WebApi.Options;

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

            services.Configure<JwtAuthoritiesOption>(_configuration);

            services.ConfigureOptions<ConfigureJwtNamedOptions>();

            services.AddAuthentication().AddJwtBearer();

            services.AddControllers();
            services.AddConnections();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}