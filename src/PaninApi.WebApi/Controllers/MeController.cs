using Microsoft.AspNetCore.Mvc;
using PaninApi.Core.Dtos.MeDtos;
using PaninApi.Core.Dtos.Services;

namespace PaninApi.WebApi.Controllers
{
    public class MeController : BaseAuthApiController
    {
        private readonly IUserService _userService;

        public MeController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            _userService.GetOrCreate();
            
            return Ok(new StudentMeDto()
            {
                
            })
        }
    }
}