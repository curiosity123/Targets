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
            throw new NotImplementedException();
        }

        public void AddStep(Token token, Guid ProjectId, string stepTitle, string stepDescription)
        {
            throw new NotImplementedException();
        }


        public void EditProject(Token token, Guid ProjectId, string updatedTitle, string updatedDescription)
        {
            throw new NotImplementedException();
        }

        public void EditStep(Token token, Guid ProjectId, Guid StepId, string updatedStepTitle, string updatedStepDescription)
        {
            throw new NotImplementedException();
        }


        public void RemoveProject(Token token, Guid ProjectId)
        {
            throw new NotImplementedException();
        }

        public void RemoveStep(Token token, Guid ProjectId, Guid StepId)
        {
            throw new NotImplementedException();
        }

         public void SetStepStatus(Token token, Guid ProjectId, Guid StepId, bool isDone)
        {
            throw new NotImplementedException();
        }
    }
}
