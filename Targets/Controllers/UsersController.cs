using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain;
using Targets.Infrastructure;

namespace Targets.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {

        private readonly IUserService service;

        public UsersController(IUserService userService)
        {
            service = userService;
        }



        [HttpGet("{Email}, {Password}")]
        public IUser Get(string Email, string Password)
        {
            return service.Get(Email, Password);
        }

        [HttpPost("RegisterAccount")]
        public void Post([FromBody] string Email, string NickName, string Password)
        {
                service.RegisterAccount(Email, NickName, Password);
        }


        [HttpDelete("DeleteAccount")]
        public void Post([FromBody] string Email, string Password)
        {
                service.DeleteAccount(Email,Password);
        }

    }
}