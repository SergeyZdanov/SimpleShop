using Database.Interface;
using Database.Models;

namespace Database.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
