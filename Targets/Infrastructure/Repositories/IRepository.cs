using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.DTO;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.Repositories
{//Update-Database
 //Add-Migration InitialCreate 
    public interface IRepository
    {
        Task RegisterAccountAsync(Credentials credentials);
        Task<IActionResult> GetProjects(Guid userId);
        Task AddNewProject(Guid userId, string title, string description);
        Task EditProject(Guid userId, Guid projectId, string updatedTitle, string updatedDescription);
        Task<User> GetAccountAsync(string Email, string Password);
        Task RemoveProject(Guid userId, Guid projectId);
        Task AddStep(Guid userId, Guid projectId, string stepTitle, string stepDescription);
        Task EditStep(Guid userId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription);
        Task RemoveStep(Guid userId, Guid projectId, Guid stepId);
        Task SetStepStatus(Guid userId, Guid projectId, Guid stepId, bool isDone);
    }
}
