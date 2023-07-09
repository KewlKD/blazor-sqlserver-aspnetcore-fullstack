using BlazorSQLServerAspNetCoreFullStack.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace BlazorSQLServerAspNetCoreFullStack.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public UserService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<User> Users { get; set; } = new List<User>();

        public async Task CreateUser(User user)
        {
            await _http.PostAsJsonAsync("api/user", user);
            _navigationManger.NavigateTo("users");
        }

        public async Task DeleteUser(int id)
        {
            var result = await _http.DeleteAsync($"api/user/{id}");
            _navigationManger.NavigateTo("users");
        }

        public async Task<User?> GetUserById(int id)
        {
            var result = await _http.GetAsync($"api/user/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<User>>("api/user");
            if (result is not null)
                Users = result;
        }

        public async Task UpdateUser(int id, User user)
        {
            await _http.PutAsJsonAsync($"api/user/{id}", user);
            _navigationManger.NavigateTo("users");
        }
    }
}