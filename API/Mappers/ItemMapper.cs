using AutoMapper;
using Database.Models;
using API.Models.Item;
using Services.Models.Item;

namespace API.Mappers
{
    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
            CreateMap<CreateItemDto, ItemResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateItemDto, UpdateItem>();

            CreateMap<UpdateItem, Item>();

            CreateMap<CreateItemDto, ItemDto>();
        }
    }
}
