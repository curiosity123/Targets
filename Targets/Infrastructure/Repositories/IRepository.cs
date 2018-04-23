using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Interfaces;

namespace Targets.Infrastructure.Repositories
{
    public interface IRepository
    {
        IUser Get(string Email, string Password);
        void RegisterAccount(string Email, string Password);
        void SetNickName(Guid UserId, string Nick);
        void DeleteAccount(string Email, string Password);

        void AddNewProject(Guid userId, string title, string description);
        void AddStep(Guid userId, string projectTitle, string stepTitle, string stepDescription);
        void EditProject(Guid userId, string title, string updatedTitle, string updatedDescription);
        void RemoveProject(Guid userId, string title);
        void EditStep(Guid userId, string projectTitle, string stepTitle, string updatedStepTitle, string updatedStepDescription);
        void RemoveStep(Guid userId, string projectTitle, string stepTitle);
        void SetStepStatus(Guid userId, string projectTitle, string stepTitle, bool isDone);
    }
}
