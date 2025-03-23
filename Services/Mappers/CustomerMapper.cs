using AutoMapper;
using Database.Models;
using Services.Models.Customer;

namespace API.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerDto, Customer>()
             .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateCustomer, Customer>();

            CreateMap<Customer, CustomerDto>();
        }
    }
}
