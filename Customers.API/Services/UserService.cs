using Customers.API.Config;
using Customers.API.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Customers.API.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly UsersApiOptions _apiConfig;

        public UserService(HttpClient httpClient, IOptions<UsersApiOptions> apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig =  apiConfig.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var listOfUsers = await _httpClient.GetAsync("http://exemple.com");

            if(listOfUsers.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User> {};
            }

            var reponseContent = listOfUsers.Content;
            var allUsers = await reponseContent.ReadFromJsonAsync<List<User>>();
            return allUsers;
        }
    }
}
