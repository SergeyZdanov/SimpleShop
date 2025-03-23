using AutoMapper;
using Database.Interface;
using Database.Models;
using Services.Intefraces;
using Services.Models.OrderItem;

namespace API.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItem> CreateAsync(OrderItemDto orderItemDto)
        {
            return await _orderItemRepository.CreateAsync(_mapper.Map<OrderItem>(orderItemDto));
        }

        public async Task<OrderItem?> GetByIdAsync(Guid id)
        {
            return await _orderItemRepository.GetAsync(id);
        }

        public async Task UpdateAsync(UpdateOrderItem orderItemDto)
        {
            await _orderItemRepository.UpdateAsync(_mapper.Map<OrderItem>(orderItemDto));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }

    }

}
