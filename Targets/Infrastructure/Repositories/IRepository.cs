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
        Task RemoveAccountAsync(Guid UserId);
        Task<List<Project>> GetProjectsAsync(Guid userId);
        Task AddNewProject(Guid userId, string title, string description);
        Task EditProject(Guid userId, Guid projectId, string updatedTitle, string updatedDescription);
        Task<User> GetAccountAsync(Guid UserId);
        Task RemoveProject(Guid userId, Guid projectId);
        Task AddStep(Guid userId, Guid projectId, string stepTitle, string stepDescription);
        Task EditStep(Guid userId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription);
        Task<User> LoginAsync(Credentials credentials);
        Task RemoveStep(Guid userId, Guid projectId, Guid stepId);
        Task SetStepStatus(Guid userId, Guid stepId, bool isDone);
    }
}
