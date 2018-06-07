using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetProjects()
        {
            return await service.GetProjects(UserId);
        }

        [HttpPost("AddProject")]
        [Authorize]
        public async Task AddProject([FromBody] NewProjectDTO prj)
        {
             await service.AddNewProject(UserId, prj.Title, prj.Description);
        }

        [HttpPost("EditProject")]
        [Authorize]
        public async Task EditProject([FromBody] EditProjectDTO prj)
        {
            await service.EditProject(UserId, prj.ProjectId, prj.UpdatedTitle, prj.UpdatedDescription);
        }


        [HttpDelete("DeleteProject")]
        [Authorize]
        public async Task DeleteProject([FromBody] RemProjectDTO  prj)
        {
            await service.DeleteProject(UserId, prj.ProjectId);
        }


        [HttpPost("SetStateStep")]
        [Authorize]
        public async Task SetStateStep([FromBody] SetStateStepDTO prj)
        {
             await service.SetStateStep(UserId, prj.ProjectId, prj.StepId, prj.IsDone);
        }


        [HttpPost("AddStep")]
        [Authorize]
        public async Task AddStep([FromBody] NewStepDTO prj)
        {
            await service.AddStep(UserId, prj.ProjectId, prj.StepTitle, prj.StepDescription);
        }

        [HttpPost("EditStep")]
        [Authorize]
        public async Task EditStep([FromBody] EditStepDTO prj)
        {
             await service.EditStep(UserId, prj.ProjectId, prj.StepId, prj.UpdatedStepTitle, prj.UpdatedStepDescription);
        }


        [HttpDelete("DeleteStep")]
        [Authorize]
        public async Task DeleteStep([FromBody] RemStepDTO prj)
        {
             await service.DeleteStep(UserId, prj.ProjectId, prj.StepId);
        }



    }
}