using Database.Interface;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public override async Task<List<Customer>> GetAllAsync()
        {
            return await Context.Customers
        .Include(o => o.Orders)
        .ThenInclude(oi => oi.ItemOrders)
        .ToListAsync();
        }
    }
}
