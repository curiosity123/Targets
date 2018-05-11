using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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




//User operations
        public Task DeleteAccountAsync(Token token)
        {
           DataBase.Remove(DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault());
            return Task.CompletedTask;
        }

        public  Task<User> GetAsync(Token token)
        {
            return Task.FromResult( DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault());
        }

        public Task RegisterAccountAsync(Token token)
        {
           DataBase.Add(new User() { Email = token.Email, Password = token.Password });
           return Task.CompletedTask;
        }



        //Project operations
        public void RemoveProject(Token token, Guid ProjectId)
        {
            DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault().Projects?.RemoveAll(x => x.Id == ProjectId);
        }

        public void EditProject(Token token, Guid ProjectId, string updatedTitle, string updatedDescription)
        {
            Project prj = DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault().Projects.Where(x => x.Id == ProjectId).FirstOrDefault();
            if (prj != null)
            {
                prj.Title = updatedTitle;
                prj.Description = updatedDescription;
            }
        }

        public void AddNewProject(Token token, string title, string description)
        {
            User usr = DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault();
            if (usr != null)
            {
                usr.Projects.Add(new Project() { Title = title, Description = description });
            }
        }




        //Step operations
        public void AddStep(Token token, Guid ProjectId, string stepTitle, string stepDescription)
        {
            Project prj = DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault().Projects.Where(x => x.Id == ProjectId).FirstOrDefault();
            if (prj != null)
            {
                prj.Steps.Add(new Step() { Title = stepTitle, Description = stepDescription, Completed = false });
            }
        }

        public void EditStep(Token token, Guid ProjectId, Guid StepId, string updatedStepTitle, string updatedStepDescription)
        {
            Project prj = DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault().Projects.Where(x => x.Id == ProjectId).FirstOrDefault();
            if (prj != null)
            {
                Step step = prj.Steps.Where(x => x.Id ==StepId).FirstOrDefault();
                if (step != null)
                {
                    step.Title = updatedStepTitle;
                    step.Description = updatedStepDescription;
                    step.Completed = false;
                }
            }
        }

        public void RemoveStep(Token token, Guid ProjectId, Guid StepId)
        {
            Project prj = DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault().Projects.Where(x => x.Id == ProjectId).FirstOrDefault();
            if (prj != null)
            {
                Step step = prj.Steps.Where(x => x.Id == StepId).FirstOrDefault();
                if (step != null)
                {
                    prj.Steps.Remove(step);
                }
            }
        }

        public void SetStepStatus(Token token, Guid ProjectId, Guid StepId, bool isDone)
        {
            Project prj = DataBase.Where(x => x.Email == token.Email && x.Password == token.Password).FirstOrDefault().Projects.Where(x => x.Id == ProjectId).FirstOrDefault();
            if (prj != null)
            {
                Step step = prj.Steps.Where(x => x.Id == StepId).FirstOrDefault();
                if (step != null)
                {
                    step.Completed = isDone;
                }
            }
        }
    }
}
