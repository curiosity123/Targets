using System;
using System.Linq;
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



        public User Get(Token token)
        {
            return GetUserByToken(token);
        }

        private User GetUserByToken(Token token)
        {
            return dbContext.Users.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault();
        }

        public void RegisterAccount(Token token)
        {
            dbContext.Users.Add(new User() { Email = token.Email, Password = token.Password });
            dbContext.SaveChanges();
        }

        public void DeleteAccount(Token token)
        {
            dbContext.Users.Remove(dbContext.Users.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault());
            dbContext.SaveChanges();
        }








        public void AddNewProject(Token token, string title, string description)
        {
            User user = GetUserByToken(token);
            if (user != null)
                user.Projects.Add(new Project() { Title = title, Description = description });
        }

        public void EditProject(Token token, Guid ProjectId, string updatedTitle, string updatedDescription)
        {
            User user = GetUserByToken(token);
            if (user != null)
            {
                Project prj = GetProjectById(ProjectId, user);
                if (prj != null)
                {
                    prj.Title = updatedTitle;
                    prj.Description = updatedDescription;
                }
            }
        }

        private static Project GetProjectById(Guid ProjectId, User user)
        {
            return user.Projects.Where(x => x.Id == ProjectId).FirstOrDefault();
        }

        public void RemoveProject(Token token, Guid ProjectId)
        {
            User user = GetUserByToken(token);
            if (user != null)
            {
                Project prj = GetProjectById(ProjectId, user);
                user.Projects.Remove(prj);
            }
        }








        public void EditStep(Token token, Guid ProjectId, Guid StepId, string updatedStepTitle, string updatedStepDescription)
        {
            User user = GetUserByToken(token);
            if (user != null)
            {
                Project prj = GetProjectById(ProjectId, user);
                if (prj != null)
                {
                    Step step = prj.Steps.Where(x => x.Id == StepId).FirstOrDefault();
                    if (step != null)
                    {
                        step.Title = updatedStepTitle;
                        step.Description = updatedStepDescription;
                    }

                }
            }
        }

        public void AddStep(Token token, Guid ProjectId, string stepTitle, string stepDescription)
        {
            User user = GetUserByToken(token);
            if (user != null)
            {
                Project prj = GetProjectById(ProjectId, user);
                if (prj != null)
                {
                    prj.Steps.Add(new Step() { Title = stepTitle, Description = stepDescription });
                }
            }
        }

        public void RemoveStep(Token token, Guid ProjectId, Guid StepId)
        {
            User user = GetUserByToken(token);
            if (user != null)
            {
                Project prj = GetProjectById(ProjectId, user);
                if (prj != null)
                {
                    Step step = prj.Steps.Where(x => x.Id == StepId).FirstOrDefault();
                    if (step != null)
                        prj.Steps.Remove(step);
                }
            }
        }

        public void SetStepStatus(Token token, Guid ProjectId, Guid StepId, bool isDone)
        {
            User user = GetUserByToken(token);
            if (user != null)
            {
                Project prj = GetProjectById(ProjectId, user);
                if (prj != null)
                {
                    Step step = prj.Steps.Where(x => x.Id == StepId).FirstOrDefault();
                    if (step != null)
                        step.Completed = isDone;
                }
            }
        }
    }
}
