using Microsoft.AspNetCore.Identity;
using Services.Models.Auth;

namespace Services.Intefraces
{
    public interface IAuthServices
    {
        Task<(bool Success, string ErroeMessage)> Register(Register dto);
        Task<SignInResult> Login(Login dto);

        Task Logout();
    }
}
