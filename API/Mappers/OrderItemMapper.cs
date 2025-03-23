using AutoMapper;
using Database.Models;
using API.Models.OrderItem;
using Services.Models.OrderItem;

namespace API.Mappers
{
    public class OrderItemMapper : Profile
    {
        public OrderItemMapper()
        {
            CreateMap<CreateOrderItemDto, OrderItemDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.ItemsCount))
            .ForMember(dest => dest.ItemPrice, opt => opt.MapFrom(src => src.ItemPrice));

            CreateMap<UpdateOrderItemDto, UpdateOrderItem>();
            CreateMap<UpdateOrderItem, OrderItem>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderItemId));
        }
    }
}
