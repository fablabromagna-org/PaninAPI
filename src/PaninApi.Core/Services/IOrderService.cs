using System.Threading.Tasks;
using PaninApi.Core.Models;

namespace PaninApi.Core.Services
{
    public interface IOrderService
    {
        Task<Order> CreateNewOrderAsync(Student student, Item item);

        Task DeleteOrderAsync(Order order);
    }
}