using Database.Models;
using Services.Models.Item;

namespace Services.Intefraces
{
    public interface IItemServices
    {
        Task<Item> CreateAsync(ItemDto item);


        Task<Item> GetByIdAsync(Guid id);

        Task<IEnumerable<Item>> GetAllByAsync();

        Task UpdateAsync(UpdateItem item);

        Task DeleteAsync(Guid id);
    }
}
