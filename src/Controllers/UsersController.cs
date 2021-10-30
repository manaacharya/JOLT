using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
/// <summary>
/// Controller for userServices, will be implemented in CRUDI operations for
/// user. 
/// </summary>
namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        /// <summary>
        /// This method will be used to create userServices object of
        /// JsonFileUserService
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(JsonFileUserService userService)

        {
            //object of userService from JsonFileUserService
            UserService = userService;
        }

        /// <summary>
        /// Get method for UserService
        /// </summary>
        public JsonFileUserService UserService { get; }


        /// <summary>
        /// This method will be used to get methods from
        /// object JsonFileUserServices
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
           return UserService.GetUsers();
        }

    }
}