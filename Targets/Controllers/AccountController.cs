using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Controllers
{

    public class AccountController : MyControllerBase
    {

        private readonly IAccountService service;

        public AccountController(IAccountService userService)
        {
            service = userService;
        }



        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            var t = await service.Login(credentials);

            if (t == null)
                return NotFound();
            return Json(t);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Credentials credentials)
        {
            if (credentials != null)
                await service.RegisterAccount(credentials);
            return Ok();

        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete()
        {
            await service.DeleteAccount(Guid.Empty);
            return Ok();//

        }


    }
}