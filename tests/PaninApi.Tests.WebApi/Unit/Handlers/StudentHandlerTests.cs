using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using PaninApi.Abstractions.Models;
using PaninApi.Abstractions.Services;
using PaninApi.Tests.WebApi.Unit.Handlers.ClassData;
using PaninApi.Tests.WebApi.Utilities;
using PaninApi.WebApi.Chains;
using PaninApi.WebApi.Consts;
using PaninApi.WebApi.Handlers.User;
using Xunit;

namespace PaninApi.Tests.WebApi.Unit.Handlers
{
    public class StudentHandlerTests
    {
        private readonly Mock<IUserChain> _nextMock;

        private readonly Mock<ISchoolService> _schoolServiceMock;

        private readonly Mock<IStudentService> _studentServiceMock;

        private readonly Mock<ILogger<StudentHandler>> _loggerMock;

        private readonly IUserChain _handler;

        public StudentHandlerTests()
        {
            _nextMock = new Mock<IUserChain>();
            _schoolServiceMock = new Mock<ISchoolService>();
            _studentServiceMock = new Mock<IStudentService>();
            _loggerMock = new Mock<ILogger<StudentHandler>>();
            _handler = new StudentHandler(_nextMock.Object, _schoolServiceMock.Object, _studentServiceMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowsArgumentNullExceptions_WhenUserClaimPrincipalIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _handler.HandleAsync(null));
            VerifyNoOtherCalls();
        }

        [Theory]
        [ClassData(typeof(StudentHandlerHandleNextHandlerClaimsClassData))]
        public async Task Handle_CallsNextHandler_WhenUserIdOrGSuiteOrgAreNull(IEnumerable<Claim> claims)
        {
            _nextMock.Setup(_ => _.HandleAsync(It.IsAny<ClaimsPrincipal>())).Returns(Task.FromResult<BaseUser>(null));
            _loggerMock.SetupDebug();

            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

            Assert.Null(await _handler.HandleAsync(claimPrincipal));

            _nextMock.Verify(_ => _.HandleAsync(It.IsAny<ClaimsPrincipal>()), Times.Once);
            _loggerMock.VerifyDebug(Times.Once);
            VerifyNoOtherCalls();
        }

        [Theory]
        [ClassData(typeof(StudentHandlerHandlerSchoolClassData))]
        public async Task Handle_Success_NoCondition(School school)
        {
            _loggerMock.SetupTrace();
            _schoolServiceMock.Setup(_ => _.GetSchoolFromStudentOrgAsync(It.IsAny<string>())).ReturnsAsync(school);
            _studentServiceMock.Setup(_ => _.GetOrCreateAsync(It.IsAny<string>(), It.IsAny<School>()))
                .ReturnsAsync(new Student());

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(CustomClaims.GSuiteOrg, "fablabromagna.org"),
            };
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

            var result = _handler.HandleAsync(claimPrincipal).ConfigureAwait(false);

            if (school is null)
            {
                Assert.Null(await result);
            }
            else
            {
                Assert.IsType<Student>(await result);
            }
        }

        private void VerifyNoOtherCalls()
        {
            _nextMock.VerifyNoOtherCalls();
            _schoolServiceMock.VerifyNoOtherCalls();
            _studentServiceMock.VerifyNoOtherCalls();
            _loggerMock.VerifyNoOtherCalls();
        }
    }
}