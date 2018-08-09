using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var user = (from x in dbContext.Users where x.Id == UserId select x).Include("Projects.Steps").FirstOrDefault();
            if (user != null)
            {
                foreach (var p in user.Projects)
                {
                    var steps = dbContext.Projects.Where(x => x.Id == p.Id).FirstOrDefault().Steps;
                    dbContext.Steps.RemoveRange(steps);
                    dbContext.Projects.Remove(p);
                }
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        #endregion

        #region User  

        public Task<User> GetAccountAsync(Guid UserId)
        {
            var u = (from x in dbContext.Users where x.Id == UserId select x).Include("Projects.Steps").FirstOrDefault();

            return Task.FromResult<User>(u);
        }

        #endregion

        #region Project

        public Task AddNewProject(Guid userId, string title, string description)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).Include("Projects").FirstOrDefault();
            if (user != null)
                user.Projects.Add(new Project() { Title = title, Description = description });
            dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task EditProject(Guid userId, Guid projectId, string updatedTitle, string updatedDescription)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).Include("Projects").FirstOrDefault();
            if (user != null)
            {
                var prj = user.Projects.Where(x => x.Id == projectId).FirstOrDefault();
                prj.Title = updatedTitle;
                prj.Description = updatedDescription;
                dbContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task<List<Project>> GetProjectsAsync(Guid userId)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).Include(x => x.Projects).FirstOrDefault();
            return Task.FromResult<List<Project>>(user.Projects);
        }

        public Task RemoveProject(Guid userId, Guid projectId)
        {
            try
            {

                var user = dbContext.Users.Where(x => x.Id == userId).Include("Projects.Steps").FirstOrDefault();
                if (user != null)
                {
                    var steps = user.Projects.Where(x => x.Id == projectId).FirstOrDefault().Steps;
                    var prj = user.Projects.Where(x => x.Id == projectId).FirstOrDefault();
                    dbContext.Steps.RemoveRange(steps);
                    dbContext.Projects.Remove(prj);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(ex);
            }
            return Task.CompletedTask;
        }

        #endregion

        #region Step

        public Task AddStep(Guid userId, Guid projectId, string stepTitle, string stepDescription)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).Include("Projects.Steps").FirstOrDefault();
            if (user != null)
            {
                var prj = user.Projects.Where(x => x.Id == projectId).FirstOrDefault();
                if (prj != null)
                {
                    prj.Steps.Add(new Step() { Title = stepTitle, Description = stepDescription, Completed = false });
                    dbContext.SaveChanges();
                }
            }

            return Task.CompletedTask;
        }

        public Task EditStep(Guid userId, Guid projectId, Guid stepId, string updatedStepTitle, string updatedStepDescription)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).Include("Projects.Steps").FirstOrDefault();
            if (user != null)
            {
                var prj = user.Projects.Where(x => x.Id == projectId).FirstOrDefault();
                if (prj != null)
                {
                    var step = prj.Steps.Where(x => x.Id == stepId).FirstOrDefault();
                    if (step != null)
                    {
                        step.Title = updatedStepTitle;
                        step.Description = updatedStepDescription;
                        dbContext.SaveChanges();
                    }
                }
            }

            return Task.CompletedTask;
        }

        public Task RemoveStep(Guid userId, Guid projectId, Guid stepId)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).Include("Projects.Steps").FirstOrDefault();
            if (user != null)
            {
                var prj = user.Projects.Where(x => x.Id == projectId).FirstOrDefault();
                if (prj != null)
                {
                    var step = prj.Steps.Where(x => x.Id == stepId).FirstOrDefault();
                    dbContext.Steps.Remove(step);
                    dbContext.SaveChanges();
                }
            }

            return Task.CompletedTask;
        }

        public Task SetStepStatus(Guid userId,Guid stepId, bool isDone)
        {
            var step = dbContext.Steps.Where(x => x.Id == stepId).FirstOrDefault();
            if (step != null && step.Completed != isDone)
            {
                step.Completed = isDone;
                dbContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        #endregion

    }
}
