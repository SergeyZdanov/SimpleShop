using Microsoft.AspNetCore.Identity;
using Services.Intefraces;
using Services.Models.Auth;
using Services.Models.Customer;

namespace Services.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICustomerServices _customerServices;

        public AuthServices(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICustomerServices customerServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerServices = customerServices;
        }

        public async Task<(bool Success, string ErroeMessage)> Register(Register dto)
        {
            if (dto.IsManager)
            {
                dto.CustomerId = null;
            }
            else
            {
                CustomerDto customerDto = new CustomerDto
                {
                    Name = "string",
                    Code = "string",
                    Address = "string"
                };
                var customer = await _customerServices.CreateAsync(customerDto);
                dto.CustomerId = customer.Id;
            }

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                CustomerId = dto.CustomerId
            };

            try
            {
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                {
                    return (false, string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }




            var role = dto.IsManager ? "Manager" : "Customer";
            await _userManager.AddToRoleAsync(user, role);
            return (true, string.Empty);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(Login dto)
        {
            var res = await _signInManager.PasswordSignInAsync(
                userName: dto.Email,
                password: dto.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );
            if (!res.Succeeded)
            {
                Console.WriteLine();
            }
            return res;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
