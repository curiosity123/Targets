using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.Repositories
{
    public class InMemoryRepository : IRepository
    {

        List<User> DataBase;

        public InMemoryRepository()
        {
            User u = new User() {  Email = "lukasz@gmail.com", Id = Guid.NewGuid(), Password = "pass" };
            u.Projects.Add(new Project() { Title = "testowy prj", Description = "desc" });
            u.Projects.Add(new Project() { Title = "testowy prj" });
            u.Projects.Add(new Project() { Title = "testowy prj" });

            u.Projects[0].Steps.Add(new Step() { Title = "step1", Description = "desc" });
            u.Projects[1].Steps.Add(new Step() { Title = "step2" });
            u.Projects[2].Steps.Add(new Step() { Title = "step1", Description = "desc" });
            u.Projects[2].Steps.Add(new Step() { Title = "step2" });

            DataBase = new List<User>();
            DataBase.Add(u);
        }

        public Task AddNewProject(Guid userId, string title, string description)
        {
            throw new NotImplementedException();
        }

        public Task AddStep(Guid userId, Guid projectId, string stepTitle, string stepDescription)
        {
            throw new NotImplementedException();
        }

        public Task EditProject(Guid userId, Guid projectId, string updatedTitle, string updatedDescription)
        {
            throw new NotImplementedException();
        }

        public Task EditStep(Guid userId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAccountAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetProjects(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAccountAsync(Credentials credentials)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProject(Guid userId, Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveStep(Guid userId, Guid projectId, Guid stepId)
        {
            throw new NotImplementedException();
        }

        public Task SetStepStatus(Guid userId, Guid projectId, Guid stepId, bool isDone)
        {
            throw new NotImplementedException();
        }
    }
}
