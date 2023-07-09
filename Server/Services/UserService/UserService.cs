using BlazorSQLServerAspNetCoreFullStack.Server.Data;
using BlazorSQLServerAspNetCoreFullStack.Shared;
using Microsoft.EntityFrameworkCore;


namespace BlazorSQLServerAspNetCoreFullStack.Server.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var dbUser = await _context.Users.FindAsync(userId);
            if (dbUser == null)
            {
                return false;
            }

            _context.Remove(dbUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User?> GetUserById(int userId)
        {
            var dbUser = await _context.Users.FindAsync(userId);
            return dbUser;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> UpdateUser(int userId, User user)
        {
            var dbUser = await _context.Users.FindAsync(userId);
            if (dbUser != null)
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Email = user.Email;

                await _context.SaveChangesAsync();
            }

            return dbUser;
        }
    }
}