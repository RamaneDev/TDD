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

        public Task<List<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
