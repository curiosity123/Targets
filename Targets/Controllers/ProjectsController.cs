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
    [Route("Projects")]
    public class ProjectsController : MyControllerBase
    {

        private readonly IProjectsService service;

        public ProjectsController(IProjectsService prjService)
        {
            service = prjService;
        }


        [HttpGet("GetProjects")]
        public async Task<IActionResult> GetProjects()
        {
            return await service.GetProjects(Guid.Empty);
        }

        [HttpPost("AddProject")]
        public async Task AddProject([FromBody] NewProjectDTO prj)
        {
             await service.AddNewProject(Guid.Empty,prj.Title, prj.Description);
        }

        [HttpPost("EditProject")]
        public async Task EditProject([FromBody] EditProjectDTO prj)
        {
            await service.EditProject(Guid.Empty, prj.ProjectId, prj.UpdatedTitle, prj.UpdatedDescription);
        }


        [HttpDelete("DeleteProject")]
        public async Task DeleteProject([FromBody] RemProjectDTO  prj)
        {
            await service.DeleteProject(Guid.Empty, prj.ProjectId);
        }


        [HttpPost("SetStateStep")]
        public async Task SetStateStep([FromBody] SetStateStepDTO prj)
        {
             await service.SetStateStep(Guid.Empty, prj.ProjectId, prj.StepId, prj.IsDone);
        }


        [HttpPost("AddStep")]
        public async Task AddStep([FromBody] NewStepDTO prj)
        {
            await service.AddStep(Guid.Empty, prj.ProjectId, prj.StepTitle, prj.StepDescription);
        }

        [HttpPost("EditStep")]
        public async Task EditStep([FromBody] EditStepDTO prj)
        {
             await service.EditStep(Guid.Empty, prj.ProjectId, prj.StepId, prj.UpdatedStepTitle, prj.UpdatedStepDescription);
        }


        [HttpDelete("DeleteStep")]
        public async Task DeleteStep([FromBody] RemStepDTO prj)
        {
             await service.DeleteStep(Guid.Empty, prj.ProjectId, prj.StepId);
        }



    }
}