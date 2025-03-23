using AutoMapper;
using API.Models.Auth;
using Services.Models.Auth;

namespace API.Mappers
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<RegisterDto, Register>();
            CreateMap<LoginDto, Login>();
        }
    }
}
