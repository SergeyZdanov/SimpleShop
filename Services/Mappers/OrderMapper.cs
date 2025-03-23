using AutoMapper;
using Database.Models;
using Services.Models.Order;
using Services.Models.OrderItem;


namespace API.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(x => x.Customer, opt => opt.MapFrom(x => x.Customer))
                .ForMember(x => x.ItemOrders, opt => opt.MapFrom(x => x.ItemOrders));

            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.ItemOrders, opt => opt.MapFrom(src => src.ItemOrders));

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<UpdateOrder, Order>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));
        }
    }
}
