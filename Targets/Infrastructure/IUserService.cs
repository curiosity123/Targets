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
        IUser Get(string Email, string Password);
        void RegisterAccount(string Email, string NickName, string Password);
        void DeleteAccount(string Email, string Password);

        void AddNewProject(string Email, string Password,string Title, string Description);
        void EditProject(string Email, string Password, string Title, string UpdatedTitle, string UpdatedDescription);
        void RemoveProject(string Email, string Password, string Title);

        void AddStep(string Email, string Password, string ProjectTitle, string StepTitle, string StepDescription);
        void RemoveStep(string Email, string Password, string ProjecttTitle, string StepTitle);
        void EditStep(string Email, string Password, string ProjectTitle, string StepTitle, string UpdatedStepTitle, string UpdatedStepDescription);

    }
}
