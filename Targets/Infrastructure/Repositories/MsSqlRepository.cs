using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.EF;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.Repositories
{
    public class MsSqlRepository : IRepository
    {
        TargetsContext dbContext;
        public MsSqlRepository(TargetsContext _context)
        {
            dbContext = _context;
        }

        public async Task AddNewProject(Guid userId, string title, string description)
        {//await dbContext.Projects.AddAsync(new Project());

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


        public Task<User> GetAccountAsync(string Email, string Password)
        {
         return Task.FromResult<User>(new User { Email = "test", Password = "pass"} );
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
