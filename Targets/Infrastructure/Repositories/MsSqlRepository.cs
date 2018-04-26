using System;
using System.Linq;
using Targets.Domain.Implementations;
using Targets.Infrastructure.EF;

namespace Targets.Infrastructure.Repositories
{
    public class MsSqlRepository : IRepository
    {
        TargetsContext dbContext;
        public MsSqlRepository(TargetsContext _context)
        {
            dbContext = _context;

        }


        public void AddNewProject(Guid userId, string title, string description)
        {
            throw new NotImplementedException();
        }

        public void AddStep(Guid userId, string projectTitle, string stepTitle, string stepDescription)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public void EditProject(Guid userId, string title, string updatedTitle, string updatedDescription)
        {
            throw new NotImplementedException();
        }

        public void EditStep(Guid userId, string projectTitle, string stepTitle, string updatedStepTitle, string updatedStepDescription)
        {
            throw new NotImplementedException();
        }

        public User Get(string Email, string Password)
        {
            dbContext.Step.Add(new Step() { Title = "dupa" });
            dbContext.SaveChanges();
            var s =  dbContext.Step.Where(x=>x.Id!=null).ToList();
            return null;//dbContext.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        }

        public void RegisterAccount(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public void RemoveProject(Guid userId, string title)
        {
            throw new NotImplementedException();
        }

        public void RemoveStep(Guid userId, string projectTitle, string stepTitle)
        {
            throw new NotImplementedException();
        }

        public void SetNickName(Guid UserId, string Nick)
        {
            throw new NotImplementedException();
        }

        public void SetStepStatus(Guid userId, string projectTitle, string stepTitle, bool isDone)
        {
            throw new NotImplementedException();
        }
    }
}
