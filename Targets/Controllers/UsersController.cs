﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Domain.Interfaces;
using Targets.Infrastructure;
using Targets.Infrastructure.Services;

namespace Targets.Controllers
{
    [Produces("application/json")]
    [Route("api/Steps")]
    public class StepsController : Controller
    {

        private readonly IStepService service;

        public StepsController(IStepService userService)
        {
            service = userService;
        }


        [HttpPost("AddStep")]
        public void Post([FromBody] User usr)
        {
            // if (usr!=null)
            //    service.AddStep(usr.Email, usr.Password);
        }


        [HttpDelete("DeleteAccount")]
        public void Delete([FromBody] User usr)
        {
           // if (usr != null)
           //     service.DeleteAccount(usr.Email, usr.Password);
        }

    }
}