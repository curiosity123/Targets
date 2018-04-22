using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain;
using Targets.Domain.Interfaces;
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
            return service.GetId(Email, Password);
        }

        [HttpPost("RegisterAccount")]
        public void Post([FromBody] string [] data)
        {
              //  service.RegisterAccount(data[0], data[1], data[2]);
        }


        [HttpDelete("DeleteAccount")]
        public void Delete([FromBody] string [] data)
        {
                service.DeleteAccount(data[0],data[1]);
        }

    }
}