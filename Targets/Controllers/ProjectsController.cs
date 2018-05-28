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
    public class ProjectsController : Controller
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
        public async Task<IActionResult> AddProject([FromBody] NewProjectDTO prj)
        {
            return await service.AddNewProject(Guid.Empty,prj.Title, prj.Description);
        }

        [HttpPost("EditProject")]
        public async Task<IActionResult> EditProject([FromBody] EditProjectDTO prj)
        {
            return await service.EditProject(Guid.Empty, prj.ProjectId, prj.UpdatedTitle, prj.UpdatedDescription);
        }


        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject([FromBody] RemProjectDTO  prj)
        {
            return await service.DeleteProject(Guid.Empty, prj.ProjectId);
        }


        [HttpPost("SetStateStep")]
        public async Task<IActionResult> SetStateStep([FromBody] SetStateStepDTO prj)
        {
            return await service.SetStateStep(Guid.Empty, prj.ProjectId, prj.StepId, prj.IsDone);
        }


        [HttpPost("AddStep")]
        public async Task<IActionResult> AddStep([FromBody] NewStepDTO prj)
        {
            return await service.AddStep(Guid.Empty, prj.ProjectId, prj.StepTitle, prj.StepDescription);
        }

        [HttpPost("EditStep")]
        public async Task<IActionResult> EditStep([FromBody] EditStepDTO prj)
        {
            return await service.EditStep(Guid.Empty, prj.ProjectId, prj.StepId, prj.UpdatedStepTitle, prj.UpdatedStepDescription);
        }


        [HttpDelete("DeleteStep")]
        public async Task<IActionResult> DeleteStep([FromBody] RemStepDTO prj)
        {
            return await service.DeleteStep(Guid.Empty, prj.ProjectId, prj.StepId);
        }



    }
}