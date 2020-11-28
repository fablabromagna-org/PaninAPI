using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaninApi.Abstractions.Models;
using PaninApi.WebApi.Chains;

namespace PaninApi.WebApi.Handlers.User
{
    public class BarmanHandler : IUserChain
    {
        private readonly PaninApiDbContext _dbContext;

        private readonly ILogger<BarmanHandler> _logger;

        public BarmanHandler(PaninApiDbContext dbContext, ILogger<BarmanHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<BaseUser> HandleAsync(ClaimsPrincipal user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userId = user.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userId?.Value))
            {
                _logger.LogDebug("{@userId} is null, finishing handling...", userId);
                return null;
            }

            return await _dbContext.Barmen.FirstOrDefaultAsync(_ => _.Id == userId.Value).ConfigureAwait(false);
        }
    }
}