using Services.Models.User;

namespace Services.Intefraces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllUsersAsync();
        Task UpdateUserRoleAsync(string userId, string role);
        Task DeleteUserAsync(string userId);
    }
}
