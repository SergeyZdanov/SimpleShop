using AutoMapper;
using API.Models.Customer;
using Services.Models.Customer;

namespace API.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerCreateDto, CustomerDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Orders, opt => opt.Ignore());

            CreateMap<UpdateCustomerDto, UpdateCustomer>();

        }
    }
}
