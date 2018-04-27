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



        [HttpGet("{token}")]
        public User Get(Token token)
        {
            return service.Get(token);
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