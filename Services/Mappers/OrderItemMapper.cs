using AutoMapper;
using Database.Models;
using Services.Models.OrderItem;

namespace Services.Mappers
{
    public class OrderItemMapper : Profile
    {
        public OrderItemMapper()
        {
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
