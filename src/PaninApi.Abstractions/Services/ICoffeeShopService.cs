using System;
using System.Threading.Tasks;
using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Services
{
    public interface ICoffeeShopService
    {
        Task<CoffeeShop> GetByIdAsync(int id);
    }
}