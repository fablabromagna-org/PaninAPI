using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaninApi.Abstractions.Models;
using PaninApi.Abstractions.Services;

namespace PaninApi.WebApi.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly PaninApiDbContext _dbContext;

        public CoffeeShopService(PaninApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CoffeeShop> GetByIdAsync(int id)
        {
            return await _dbContext.CoffeeShops.Include(_ => _.Items).FirstOrDefaultAsync(_ => _.Id == id).ConfigureAwait(false);
        }
    }
}