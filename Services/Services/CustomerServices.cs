using AutoMapper;
using Database.Interface;
using Database.Models;
using Services.Intefraces;
using Services.Models.Customer;

namespace API.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerServices(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> CreateAsync(CustomerDto customerDto)
        {
            return await _customerRepository.CreateAsync(_mapper.Map<Customer>(customerDto));
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _customerRepository.GetAsync(id);
        }

        public async Task UpdateCustomerAsync(Guid id, UpdateCustomer customerDto)
        {
            customerDto.Id = id;
            await _customerRepository.UpdateAsync(_mapper.Map<Customer>(customerDto));
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
