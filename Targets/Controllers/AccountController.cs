using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : MyControllerBase
    {

        private readonly IAccountService service;

        public AccountController(IAccountService userService)
        {
            service = userService;
        }



        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            var token = await service.LoginAsync(credentials);
            if (token != null)
            {
                var j = Json(token);
                return j;
            }
            else
                return NotFound();
        }



        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]Credentials credentials)
        {
              if (credentials != null)
                 await service.RegisterAccount(credentials);
            return Created(credentials.Email, null);

        }


        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            await service.DeleteAccount(UserId);
            return Ok();//

        }


    }
}