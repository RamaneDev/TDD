using Customers.API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customers.API.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var listOfUsers = await _httpClient.GetAsync("http://exemple.com");

            return new List<User> { };
        }
    }
}
