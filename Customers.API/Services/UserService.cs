using Customers.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customers.API.Services
{
    public class UserService : IUserService
    {
        public UserService() { }

        public Task<List<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
