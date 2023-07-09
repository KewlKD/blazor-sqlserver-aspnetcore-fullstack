using BlazorSQLServerAspNetCoreFullStack.Server.Services.UserService;
using BlazorSQLServerAspNetCoreFullStack.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BlazorSQLServerAspNetCoreFullStack.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<User?> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost]
        public async Task<User?> CreateUser(User user)
        {
            return await _userService.CreateUser(user);
        }

        [HttpPut("{id}")]
        public async Task<User?> UpdateUser(int id, User user)
        {
            return await _userService.UpdateUser(id, user);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
