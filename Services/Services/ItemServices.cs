using AutoMapper;
using Database.Interface;
using Database.Models;
using Services.Intefraces;
using Services.Models.Item;

namespace API.Services
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemServices(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<Item> CreateAsync(ItemDto item)
        {
            return await _itemRepository.CreateAsync(_mapper.Map<Item>(item));
        }

        public async Task<Item> GetByIdAsync(Guid id)
        {
            return await _itemRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAllByAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task UpdateAsync(UpdateItem item)
        {
            await _itemRepository.UpdateAsync(_mapper.Map<Item>(item));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _itemRepository.DeleteAsync(id);
        }

    }
}
