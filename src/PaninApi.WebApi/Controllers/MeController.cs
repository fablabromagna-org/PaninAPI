using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Dtos.MeDtos;
using PaninApi.Abstractions.Models;
using PaninApi.Abstractions.Services;
using PaninApi.WebApi.Chains;

namespace PaninApi.WebApi.Controllers
{
    public class MeController : BaseAuthApiController
    {
        private readonly IUserChain _userChain;

        private readonly IMapper _mapper;

        private readonly IStudentService _studentService;

        public MeController(IUserChain userChain, IMapper mapper, IStudentService studentService)
        {
            _userChain = userChain;
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userChain.HandleAsync(HttpContext.User);

            if (user is null)
            {
                return Forbid();
            }

            var dto = _mapper.Map(user, user.GetType(), typeof(MeDto));

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> StudentClass(InputStudentClassDto studentClassDto)
        {
            // ToDo: refactor with policies
            if (!(await _userChain.HandleAsync(HttpContext.User) is Student student))
            {
                return Forbid();
            }

            var studentClass = _mapper.Map<StudentClass>(studentClassDto);

            await _studentService.SetStudentClassAsync(student, studentClass);

            return Ok();
        }
    }
}