using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models.Customer;
using Services.Intefraces;
using Services.Models.Customer;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerServices customerServices, IMapper mapper)
        {
            _mapper = mapper;
            _customerServices = customerServices;
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCustomers([FromBody] CustomerCreateDto dto)
        {
            var res = await _customerServices.CreateAsync(_mapper.Map<CustomerDto>(dto));
            return CreatedAtAction(nameof(GetCustomerById), new { id = res.Id }, res);
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerServices.GetAllCustomersAsync();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _customerServices.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerDto customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            await _customerServices.UpdateCustomerAsync(id, _mapper.Map<UpdateCustomer>(customer));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerServices.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
