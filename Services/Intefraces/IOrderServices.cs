using Database.Models;
using Services.Models.Order;
using Shared;

namespace Services.Intefraces
{
    public interface IOrderServices
    {
        Task<Order> CreateAsync(OrderDto order);

        Task<IEnumerable<Order>> GetAllOrdersAsync(Guid? customerId, OrderStatus? status);

        Task<Order> GetOrderByIdAsync(Guid id);
        Task UpdateOrderAsync(Guid id, UpdateOrder order);

        Task DeleteOrderAsync(Guid id);
    }
}
