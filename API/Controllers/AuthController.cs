using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Models.Auth;
using Services.Intefraces;
using Services.Models.Auth;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly IMapper _mapper;
        public AuthController(IAuthServices authServices, IMapper mapper)
        {
            _authServices = authServices;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {

            var res = await _authServices.Register(_mapper.Map<Register>(dto));

            if (!res.Success)
            {
                return BadRequest();
            }

            var role = dto.IsManager ? "Manager" : "Customer";
            return Ok($"User created with role={role}");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authServices.Login(_mapper.Map<Login>(dto));

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok("Logged in!");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authServices.Logout();
            return Ok("Logged out");
        }
    }
}