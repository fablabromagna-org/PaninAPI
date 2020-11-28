using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaninApi.WebApi.Chains;

namespace PaninApi.WebApi.Controllers
{
    public class MeController : BaseAuthApiController
    {
        private readonly IUserChain _userChain;

        public MeController(IUserChain userChain)
        {
            _userChain = userChain;
        }

        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var user = await _userChain.HandleAsync(HttpContext.User);

            return null;
        }
    }
}