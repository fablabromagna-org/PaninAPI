using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaninApi.Core.Services;
using PaninApi.WebApi.Consts;

namespace PaninApi.WebApi.Controllers
{
    public class MeController : BaseAuthApiController
    {
        private readonly ISchoolService _schoolService;

        public MeController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var org = HttpContext.User.Claims.FirstOrDefault(_ => _.Type == CustomClaims.GSuiteOrg);

            if (org is null)
            {
                
            }
        }
    }
}