using System;
using Microsoft.AspNetCore.Mvc;
using PaninApi.Core.Dtos.MeDtos;
using PaninApi.Core.Dtos.Services;

namespace PaninApi.WebApi.Controllers
{
    public class MeController : BaseApiController
    {
        private readonly IUserService _userService;

        public MeController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            string test = DateTime.Now.ToUniversalTime().ToString();
            
            throw new NotImplementedException();
        }
    }
}