using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Infrastructure.DTO;

namespace Targets.Controllers
{
    public interface IProjectsService
    {
        Task<IActionResult> GetProjects(Guid UserId);
        Task<IActionResult> AddNewProject(Guid UserId, string title, string description);
        Task<IActionResult> EditProject(Guid UserId, Guid projectId, string updatedTitle, string updatedDescription);
        Task<IActionResult> DeleteProject(Guid UserId, Guid projectId, string updatedTitle, string updatedDescription);
        Task<IActionResult> SetStateStep(Guid UserId, Guid projectId, Guid stepId, bool isDone);
        Task<IActionResult> AddStep(Guid UserId, Guid projectId, string stepTitle, string stepDescription);
        Task<IActionResult> EditStep(Guid UserId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription);
        Task<IActionResult> DeleteProject(Guid UserId, Guid projectId);
        Task<IActionResult> DeleteStep(Guid UserId, Guid projectId, Guid stepId);
    }
}