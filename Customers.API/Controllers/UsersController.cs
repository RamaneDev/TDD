using Customers.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Customers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            await _userService.GetAllUsers();
            return Ok("all good");
        }
    }
}
