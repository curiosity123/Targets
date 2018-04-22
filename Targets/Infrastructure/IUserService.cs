using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Interfaces;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        IUser GetId(string Email, string Password);
        void RegisterAccount(string Email, string Password);
        void DeleteAccount(string Email, string Password);
        void SetPhoto(Guid UserId, byte[] Photo);
        void SetNickName(Guid UserId, string Nick);

        void SetPrize(int StepLevel, string Description);


        List<IProject> GetProjects(Guid UserId);

        void AddNewProject(Guid UserId, string Title, string Description);
        void EditProject(Guid UserId, string Title, string UpdatedTitle, string UpdatedDescription);
        void RemoveProject(Guid UserId, string Title);

        void AddStep(Guid UserId, string ProjectTitle, string StepTitle, string StepDescription);
        void RemoveStep(Guid UserId, string ProjecttTitle, string StepTitle);
        void EditStep(Guid UserId, string ProjectTitle, string StepTitle, string UpdatedStepTitle, string UpdatedStepDescription);
        void SetStepStatus(Guid UserId, bool IsDone);

    }
}
