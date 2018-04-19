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

        [HttpGet("{Email}")]
        public IUser Get(string Email)
        {
            return service.Get(Email);
        }
        [HttpGet("")]
        public IEnumerable<IUser> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost("Create")]
        public void Post([FromBody] User user)
        {
            try
            {
                service.Create(user.Email, user.NickName, user.Password);
            }
            catch { }
        }


        [HttpDelete("Delete")]
        public void Post([FromBody] string email)
        {
            try
            {
                service.Delete(email);
            }
            catch { }
        }

    }
}