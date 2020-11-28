using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PaninApi.Abstractions.Models;
using PaninApi.Abstractions.Services;
using PaninApi.WebApi.Chains;
using PaninApi.WebApi.Consts;

namespace PaninApi.WebApi.Handlers.User
{
    public class StudentHandler : IUserChain
    {
        private readonly IUserChain _next;

        private readonly ISchoolService _schoolService;

        private readonly IStudentService _studentService;

        private readonly ILogger<StudentHandler> _logger;

        public StudentHandler(IUserChain next, ISchoolService schoolService, IStudentService studentService,
            ILogger<StudentHandler> logger)
        {
            _next = next;
            _schoolService = schoolService;
            _studentService = studentService;
            _logger = logger;
        }

        public async Task<BaseUser> HandleAsync(ClaimsPrincipal user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userId = user.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier);
            var gSuiteOrg = user.Claims.FirstOrDefault(_ => _.Type == CustomClaims.GSuiteOrg);

            if (string.IsNullOrWhiteSpace(userId?.Value) || string.IsNullOrWhiteSpace(gSuiteOrg?.Value))
            {
                _logger.LogDebug("{@userId} and/or {@gSuiteOrg} is/are null, passing request to next handler.", userId,
                    gSuiteOrg);
                return await _next.HandleAsync(user).ConfigureAwait(false);
            }

            School school = await _schoolService.GetSchoolFromStudentOrgAsync(gSuiteOrg.Value).ConfigureAwait(false);
            
            if (school is null)
            {
                _logger.LogTrace("School not found.");
                return null;
            }
            
            _logger.LogTrace("Found user's school: {@school}", school);

            return await _studentService.GetOrCreateAsync(userId.Value, school).ConfigureAwait(false);
        }
    }
}