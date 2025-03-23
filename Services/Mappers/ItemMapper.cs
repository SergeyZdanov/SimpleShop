using AutoMapper;
using Database.Models;
using Services.Models.Item;


namespace API.Mappers
{
    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
            CreateMap<ItemDto, Item>();
        }
    }
}
