﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;

namespace Targets.Controllers
{
    public interface IProjectsService
    {
        Task<List<Project>> GetProjects(Guid UserId);
        Task AddNewProject(Guid UserId, string title, string description);
        Task EditProject(Guid UserId, Guid projectId, string updatedTitle, string updatedDescription);
        Task SetStateStep(Guid UserId, Guid stepId, bool isDone);
        Task AddStep(Guid UserId, Guid projectId, string stepTitle, string stepDescription);
        Task EditStep(Guid UserId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription);
        Task DeleteProject(Guid UserId, Guid projectId);
        Task DeleteStep(Guid UserId, Guid projectId, Guid stepId);
    }
}