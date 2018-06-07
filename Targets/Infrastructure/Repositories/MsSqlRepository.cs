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


        #region Account

        public Task<User> LoginAsync(Credentials credentials)
        {
            var user = (from x in dbContext.Users where x.Email == credentials.Email && x.Password == credentials.Password select x).FirstOrDefault();
            return Task.FromResult<User>(user);
        }

        public Task RegisterAccountAsync(Credentials credentials)
        {
            if ((from x in dbContext.Users where x.Email == credentials.Email select x).Count() == 0)
                dbContext.Users.Add(new User() { Email = credentials.Email, Password = credentials.Password });
            dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RemoveAccountAsync(Guid UserId)
        {
            var user = (from x in dbContext.Users where x.Id == UserId select x).FirstOrDefault();
            if (user != null)
                dbContext.Users.Remove(user);
            return Task.CompletedTask;
        }

        #endregion

        #region User  

        public Task<User> GetAccountAsync(Guid UserId)
        {
            return Task.FromResult<User>((from x in dbContext.Users where x.Id == UserId select x).FirstOrDefault());
        }

        #endregion


        #region Project

        public Task AddNewProject(Guid userId, string title, string description)
        {//await dbContext.Projects.AddAsync(new Project());
            throw new NotImplementedException();
        }

        public Task EditProject(Guid userId, Guid projectId, string updatedTitle, string updatedDescription)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetProjects(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProject(Guid userId, Guid projectId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Step

        public Task AddStep(Guid userId, Guid projectId, string stepTitle, string stepDescription)
        {
            throw new NotImplementedException();
        }

        public Task EditStep(Guid userId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription)
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

        #endregion



    }
}
