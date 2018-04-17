using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Targets.Infrastructure;

namespace Targets.Controllers
{
    //[Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {

        private readonly IUserService service;

        public UsersController(IUserService userService)
        {
            service = userService;
        }

        [HttpGet("{Email}")]
        public string Get(string Email)
        {
            return service.Get(Email).NickName;
        }
        [HttpGet("")]
        public string GetAll()
        {
            return service.GetAll().Count().ToString();
        }


    }
}