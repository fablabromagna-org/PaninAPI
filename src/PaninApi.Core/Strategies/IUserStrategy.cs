using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PaninApi.Core.Dtos.MeDtos;

namespace PaninApi.Core.Strategies
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TUserDto"></typeparam>
    public interface IUserStrategy<TUserDto> where TUserDto : MeDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool VerifyIfCompatible(HttpContext httpContext);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<TUserDto> PerformRequestAsync();
    }
}