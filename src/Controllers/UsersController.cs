using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController(JsonFileUserService userService)
        {
            UserService = userService;
        }

        public JsonFileUserService UserService { get; }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return UserService.GetUsers();
        }

    }
}