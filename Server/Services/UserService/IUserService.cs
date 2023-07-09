using BlazorSQLServerAspNetCoreFullStack.Shared;

namespace BlazorSQLServerAspNetCoreFullStack.Server.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(int userId);
        Task<User> CreateUser(User user);
        Task<User?> UpdateUser(int userId, User user);
        Task<bool> DeleteUser(int userId);
    }
}
