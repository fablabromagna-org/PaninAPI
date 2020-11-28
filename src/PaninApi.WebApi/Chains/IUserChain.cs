using System.Security.Claims;
using System.Threading.Tasks;
using PaninApi.Abstractions.Models;

namespace PaninApi.WebApi.Chains
{
    public interface IUserChain
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<BaseUser> HandleAsync(ClaimsPrincipal user);
    }
}