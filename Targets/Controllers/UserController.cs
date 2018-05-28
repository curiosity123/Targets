using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Controllers
{
    [Produces("application/json")]
    [Route("User")]
    public class UserController : Controller
    {

        private readonly IUserService service;

        public UserController(IUserService userService)
        {
            service = userService;
        }



        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return await service.GetAccount(Guid.Empty);

        }

    }
}