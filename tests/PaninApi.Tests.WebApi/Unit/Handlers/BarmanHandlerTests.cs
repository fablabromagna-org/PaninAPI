using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using PaninApi.Abstractions.Models;
using PaninApi.Tests.WebApi.Unit.Handlers.ClassData;
using PaninApi.Tests.WebApi.Utilities;
using PaninApi.WebApi;
using PaninApi.WebApi.Chains;
using PaninApi.WebApi.Handlers.User;
using Xunit;

namespace PaninApi.Tests.WebApi.Unit.Handlers
{
    public class BarmanHandlerTests
    {
        private readonly PaninApiDbContext _dbContext;

        private readonly Mock<ILogger<BarmanHandler>> _loggerMock;

        private readonly IUserChain _handler;

        public BarmanHandlerTests()
        {
            _dbContext = new DbContextFactory().DbContext;
            _loggerMock = new Mock<ILogger<BarmanHandler>>();
            _handler = new BarmanHandler(_dbContext, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_ThrowsArgumentNullExceptions_WhenUserClaimPrincipalIsNull()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _handler.HandleAsync(null));
            _loggerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [ClassData(typeof(BarmanHandlerHandlerClaimsClassData))]
        public async Task Handle_ReturnsNull_WhenUserIdClaimIsNotAvailable(IEnumerable<Claim> claims)
        {
            _loggerMock.SetupDebug();
            
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

            Assert.Null(await _handler.HandleAsync(claimPrincipal));
            _loggerMock.VerifyDebug(Times.Once).VerifyNoOtherCalls();
        }

        [Fact]
        public async Task Handle_ReturnsNull_WhenUserDoesNotExists()
        {
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            }));

            Assert.Null(await _handler.HandleAsync(claimPrincipal));
            
            _loggerMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Handle_Success_NoCondition()
        {
            var barman = new Barman()
            {
                Id = Guid.NewGuid().ToString()
            };
            await _dbContext.AddAsync(barman);
            await _dbContext.SaveChangesAsync();
            
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.NameIdentifier, barman.Id)
            }));

            Assert.IsType<Barman>(await _handler.HandleAsync(claimPrincipal));
            
            _loggerMock.VerifyNoOtherCalls();
        }
    }
}