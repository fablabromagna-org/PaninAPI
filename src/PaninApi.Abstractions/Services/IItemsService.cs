using System;
using System.Threading.Tasks;
using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Services
{
    public interface IItemService
    {
        public Task<Item> FindAsync(Guid id);

        public Task<bool> IsAvailableAsync(Item item, int quantity);
    }
}