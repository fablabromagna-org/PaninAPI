using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PaninApi.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(Configure);

        public static void Configure(IWebHostBuilder webBuilder)
        {
            webBuilder.ConfigureKestrel(options => options.AddServerHeader = false);
            webBuilder.UseStartup<Startup>();
        }
    }
}