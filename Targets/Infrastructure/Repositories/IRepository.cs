using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.Repositories
{
    public interface IRepository
    {
        Task<User> GetAccountAsync(Guid UserId);
        Task RegisterAccountAsync(Credentials credentials);
        Task DeleteAccountAsync(TokenDTO token);

        void AddNewProject(Guid UserId, string title, string description);
        void AddStep(Guid UserId, Guid ProjectId, string stepTitle, string stepDescription);
        void EditProject(Guid UserId, Guid ProjectId, string updatedTitle, string updatedDescription);
        void RemoveProject(Guid UserId, Guid ProjectId);
        void EditStep(Guid UserId, Guid ProjectId, Guid StepId, string updatedStepTitle, string updatedStepDescription);
        void RemoveStep(Guid UserId, Guid ProjectId, Guid StepId);
        void SetStepStatus(Guid UserId, Guid ProjectId, Guid StepId, bool isDone);


    }
}
