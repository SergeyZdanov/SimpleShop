using Database.Interface;
using Database.Models;

namespace Database.Repository
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
