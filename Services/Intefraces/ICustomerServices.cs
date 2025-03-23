using Database.Models;
using Services.Models.Customer;

namespace Services.Intefraces
{
    public interface ICustomerServices
    {
        Task<Customer> CreateAsync(CustomerDto customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task UpdateCustomerAsync(Guid id, UpdateCustomer customer);

        Task DeleteCustomerAsync(Guid id);
    }
}
