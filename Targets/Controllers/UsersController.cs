using Microsoft.AspNetCore.Mvc;
using Targets.Domain.Implementations;
using Targets.Infrastructure;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

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



        [HttpGet("{Email},{Password}")]
        public User Get(string Email, string Password)
        {
            return service.Get(new Token() { Email = Email, Password = Password});
        }


        [HttpPost("RegisterAccount")]
        public void Post([FromBody] Token token)
        {
            if (token != null)
                service.RegisterAccount(token);
        }


        [HttpDelete("DeleteAccount")]
        public void Delete([FromBody] Token token)
        {
            if (token != null)
                service.DeleteAccount(token);
        }

    }
}