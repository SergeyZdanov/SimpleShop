using AutoMapper;
using Database.Models;
using API.Models.Order;
using Services.Models.Order;

namespace API.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<CreateOrderDto, OrderDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
                .ForMember(dest => dest.ShipmentDate, opt => opt.Ignore())
                .ForMember(dest => dest.ItemOrders, opt => opt.MapFrom(src => src.Items));

            CreateMap<UpdateOrderDto, UpdateOrder>();

            CreateMap<Order, UpdateOrder>();

            CreateMap<UpdateOrderDto, Order>()
           .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
           .ForMember(dest => dest.ItemOrders, opt => opt.Ignore())
           .ForMember(dest => dest.Customer, opt => opt.Ignore());
        }
    }
}
