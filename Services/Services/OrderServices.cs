using AutoMapper;
using Database.Interface;
using Database.Models;
using Services.Intefraces;
using Services.Models.Order;
using Shared;

namespace API.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderServices(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Order> CreateAsync(OrderDto order)
        {
            order.Status = OrderStatus.New;
            return await _orderRepository.CreateAsync(_mapper.Map<Order>(order));
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            return (await _orderRepository.GetAllAsync())
                .Where(o => o.CustomerId == customerId)
                .ToList();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(Guid? customerId, OrderStatus? status)
        {
            return await _orderRepository.GetAllAsync(customerId, status);
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _orderRepository.GetAsync(id);
        }

        public async Task UpdateOrderAsync(Guid id, UpdateOrder order)
        {
            order.Id = id;
            await _orderRepository.UpdateAsync(_mapper.Map<Order>(order));
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await GetOrderByIdAsync(id);
            if (order.Status != OrderStatus.New)
            {
                throw new Exception("Заказ не может быть удален");
            }
            await _orderRepository.DeleteAsync(id);
        }
    }
}
