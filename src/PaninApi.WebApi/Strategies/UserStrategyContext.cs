using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PaninApi.Core.Dtos.MeDtos;
using PaninApi.Core.Strategies;

namespace PaninApi.WebApi.Strategies
{
    public class UserStrategyContext : IUserStrategyContext
    {
        private readonly IUserStrategiesCollection
        
        public UserStrategyContext(IUserStrategiesCollection collection)
        {
            
        }
        
        public Task<MeDto> Delegate(HttpContext httpContext)
        {
            throw new System.NotImplementedException();
        }
    }
}