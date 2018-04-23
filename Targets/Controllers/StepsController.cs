using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Domain.Interfaces;
using Targets.Infrastructure;
using Targets.Infrastructure.DTO;
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

        [HttpPost("Add")]
        public void Post([FromBody] NewStepDto obj)
        {
            if (obj != null)
                service.AddStep(obj.UserId, obj.ProjectTitle, obj.StepTitle, obj.StepDescription);
        }

        [HttpPost("Edit")]
        public void Post([FromBody] EditStepDto obj)
        {
            if (obj != null)
                service.EditStep(obj.UserId, obj.ProjectTitle, obj.StepTitle, obj.UpdatedStepTitle, obj.UpdatedStepDescription);
        }


        [HttpDelete("Delete")]
        public void Delete([FromBody] RemStepDto obj)
        {
            if (obj != null)
                service.RemoveStep(obj.UserId, obj.ProjectTitle, obj.StepTitle);
        }

        [HttpPost("SetState")]
        public void SetState([FromBody] SetStateStepDto obj)
        {
            if (obj != null)
                service.SetStepStatus(obj.UserId, obj.ProjectTitle, obj.StepTitle,obj.IsDone);
        }
    }
}