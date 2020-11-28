using System.Threading.Tasks;
using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Services
{
    public interface IOrderService
    {
        Task<Order> CreateNewOrderAsync(Student student, Item item);

        Task DeleteOrderAsync(Order order);
    }
}