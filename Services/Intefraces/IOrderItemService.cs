using Database.Models;
using Services.Models.OrderItem;

namespace Services.Intefraces
{
    public interface IOrderItemService
    {
        Task<OrderItem> CreateAsync(OrderItemDto orderItem);

        Task<OrderItem?> GetByIdAsync(Guid id);

        Task UpdateAsync(UpdateOrderItem orderItem);

        Task DeleteAsync(Guid id);
    }
}
