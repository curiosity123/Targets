using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Domain.Interfaces;

namespace Targets.Infrastructure
{
    public class UserService : IUserService
    {

        List<IUser> Users;

        public UserService()
        {
            Users = new List<IUser>();// { new User() { NickName = "lukasz", Email = "luki@p.pl", Id = Guid.NewGuid(), Password = "testowe haslo" } };
        }

        public void AddNewProject(Guid UserId, string Title, string Description)
        {
            throw new NotImplementedException();
        }

        public void AddStep(Guid UserId, string ProjectTitle, string StepTitle, string StepDescription)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public void EditProject(Guid UserId, string Title, string UpdatedTitle, string UpdatedDescription)
        {
            throw new NotImplementedException();
        }

        public void EditStep(Guid UserId, string ProjectTitle, string StepTitle, string UpdatedStepTitle, string UpdatedStepDescription)
        {
            throw new NotImplementedException();
        }

        public IUser GetId(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public List<IProject> GetProjects(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public void RegisterAccount(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public void RemoveProject(Guid UserId, string Title)
        {
            throw new NotImplementedException();
        }

        public void RemoveStep(Guid UserId, string ProjecttTitle, string StepTitle)
        {
            throw new NotImplementedException();
        }

        public void SetNickName(Guid UserId, string Nick)
        {
            throw new NotImplementedException();
        }

        public void SetPhoto(Guid UserId, byte[] Photo)
        {
            throw new NotImplementedException();
        }

        public void SetPrize(int StepLevel, string Description)
        {
            throw new NotImplementedException();
        }

        public void SetStepStatus(Guid UserId, bool IsDone)
        {
            throw new NotImplementedException();
        }
    }
}
