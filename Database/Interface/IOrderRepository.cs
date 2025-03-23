using Database.Models;
using Shared;

namespace Database.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<List<Order>> GetAllAsync(Guid? customerId, OrderStatus? status);
    }
}
