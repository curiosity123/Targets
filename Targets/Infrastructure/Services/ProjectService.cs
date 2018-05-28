using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Controllers;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Repositories;

namespace Targets.Infrastructure.Services
{
    public class ProjectService : IProjectsService
    {

        IRepository repo;
        public ProjectService(IRepository _repo)
        {
            repo = _repo;
        }

        


        public Task<IActionResult> GetProjects(Guid UserId)
        {
            return await repo.GetProjects(UserId);
        }

        public Task<IActionResult> AddNewProject(Guid UserId, string title, string description)
        {
            return await repo.AddNewProject(UserId, title, description);
        }

        public Task<IActionResult> EditProject(Guid UserId, Guid projectId, string updatedTitle, string updatedDescription)
        {
            return await repo.EditProject(UserId, projectId, updatedTitle, updatedDescription);
        }


        public Task<IActionResult> SetStateStep(Guid UserId, Guid projectId, Guid stepId, bool isDone)
        {
            return await repo.SetStepStatus(UserId, projectId, stepId, isDone);
        }

        public Task<IActionResult> AddStep(Guid UserId, Guid projectId, string stepTitle, string stepDescription)
        {
            return await repo.AddStep(UserId, projectId, stepTitle, stepDescription);
        }

        public Task<IActionResult> EditStep(Guid UserId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription)
        {
            return await repo.EditStep(UserId, projectId, stepId, updatedStepTitle, updatedStepDescription);
        }



        public Task<IActionResult> DeleteProject(Guid UserId, Guid projectId)
        {
            return await repo.RemoveProject(UserId, projectId);
        }

        public Task<IActionResult> DeleteStep(Guid UserId, Guid projectId, Guid stepId)
        {
          return await repo.RemoveStep(UserId, projectId, stepId);
        }
    }
}
