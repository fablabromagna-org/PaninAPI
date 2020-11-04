using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Moq;
using PaninApi.WebApi.Options;
using Xunit;
using MsExtensionsOptions = Microsoft.Extensions.Options.Options;

namespace PaninApi.Tests.WebApi.Unit.Options
{
    public class ConfigureJwtNamedOptionsTests
    {
        [Fact]
        public void Configure_Success_WhenNoNameIsProvided()
        {
            var mock = new Mock<ConfigureJwtNamedOptions>(MsExtensionsOptions.Create(new JwtAuthoritiesOption()))
                {
                    CallBase = true
                }
                .As<IConfigureNamedOptions<JwtBearerOptions>>();

            mock.Setup(_ => _.Configure(It.IsAny<string>(), It.IsAny<JwtBearerOptions>()));

            mock.Object.Configure(new JwtBearerOptions());

            mock.Verify(_ => _.Configure(It.IsAny<string>(), It.IsAny<JwtBearerOptions>()), Times.Once);
            mock.VerifyNoOtherCalls();
        }
    }
}