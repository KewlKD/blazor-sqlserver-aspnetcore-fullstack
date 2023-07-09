using BlazorSQLServerAspNetCoreFullStack.Shared;

namespace BlazorSQLServerAspNetCoreFullStack.Client.Services.UserService
{
    public interface IUserService
    {
        List<User> Users { get; set; }
        Task GetUsers();
        Task<User?> GetUserById(int id);
        Task CreateUser(User user);
        Task UpdateUser(int id, User user);
        Task DeleteUser(int id);
    }
}
