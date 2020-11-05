using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PaninApi.Core.Dtos.MeDtos;

namespace PaninApi.Core.Strategies
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserStrategyContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        Task<MeDto> Delegate(HttpContext httpContext);
    }
}