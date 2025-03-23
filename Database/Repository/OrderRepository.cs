using Database.Interface;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Database.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public async Task<List<Order>> GetAllAsync(Guid? customerId, OrderStatus? status)
        {
            IQueryable<Order> query = Context.Orders;

            if (customerId.HasValue)
            {
                query = query.Where(o => o.CustomerId == customerId.Value);
            }

            query = query.Where(o => o.Status == status);


            return await query.ToListAsync();
        }
    }
}
