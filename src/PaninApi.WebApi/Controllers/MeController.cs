using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaninApi.Abstractions.Dtos.MeDtos;
using PaninApi.WebApi.Chains;

namespace PaninApi.WebApi.Controllers
{
    public class MeController : BaseAuthApiController
    {
        private readonly IUserChain _userChain;

        private readonly IMapper _mapper;

        public MeController(IUserChain userChain, IMapper mapper)
        {
            _userChain = userChain;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userChain.HandleAsync(HttpContext.User);
            var dto = _mapper.Map(user, user.GetType(), typeof(MeDto));
            
            return Ok(dto);
        }
    }
}