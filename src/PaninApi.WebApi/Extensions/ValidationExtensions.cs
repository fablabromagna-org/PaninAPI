using Microsoft.Extensions.DependencyInjection;

namespace PaninApi.WebApi.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidationExtensions(this IServiceCollection services)
        {
            return services;
        }
    }
}