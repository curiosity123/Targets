using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Controllers;
using Targets.Domain.Implementations;
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

        


        public Task<List<Project>> GetProjects(Guid UserId)
        {
            return repo.GetProjectsAsync(UserId);
        }

        public Task AddNewProject(Guid UserId, string title, string description)
        {
            return repo.AddNewProject(UserId, title, description);
        }

        public Task EditProject(Guid UserId, Guid projectId, string updatedTitle, string updatedDescription)
        {
            return repo.EditProject(UserId, projectId, updatedTitle, updatedDescription);
        }


        public  Task SetStateStep(Guid UserId, Guid stepId, bool isDone)
        {
            return repo.SetStepStatus(UserId, stepId, isDone);
        }

        public Task AddStep(Guid UserId, Guid projectId, string stepTitle, string stepDescription)
        {
            return repo.AddStep(UserId, projectId, stepTitle, stepDescription);
        }

        public Task EditStep(Guid UserId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription)
        {
            return repo.EditStep(UserId, projectId, stepId, updatedStepTitle, updatedStepDescription);
        }



        public Task DeleteProject(Guid UserId, Guid projectId)
        {
            return repo.RemoveProject(UserId, projectId);
        }

        public Task DeleteStep(Guid UserId, Guid projectId, Guid stepId)
        {
          return repo.RemoveStep(UserId, projectId, stepId);
        }
    }
}
