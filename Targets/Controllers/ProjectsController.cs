using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Infrastructure;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Controllers
{
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {

        private readonly IProjectService service;

        public ProjectsController(IProjectService userService)
        {
            service = userService;
        }



        [HttpPost("Add")]
        public void Post([FromBody] NewPrjDto prj)
        {
             if (prj!=null)
                service.AddNewProject(prj.token,prj.Title, prj.Description);
        }

        [HttpPost("Edit")]
        public void Post([FromBody] EditPrjDto prj)
        {
            if (prj != null)
                service.EditProject(prj.token, prj.PrjectId,prj.UpdatedTitle, prj.UpdatedDescription);
        }


        [HttpDelete("Delete")]
        public void Delete([FromBody] EditPrjDto prj)
        {
            if (prj != null)
                service.RemoveProject(prj.token, prj.PrjectId);
        }

    }
}