using Customers.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customers.API.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
}
