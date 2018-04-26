using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Implementations;

namespace Targets.Infrastructure.Repositories
{
    public class InMemoryRepository : IRepository
    {

        List<User> DataBase;

        public InMemoryRepository()
        {
            DataBase = new List<User>() { new User() { NickName = "lukasz", Email = "lukasz@gmail.com", Id = Guid.NewGuid(), Password = "pass" } };
        }




//User operations
        public void DeleteAccount(string Email, string Password)
        {
            DataBase.Remove(DataBase.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault());
        }

        public User Get(string Email, string Password)
        {
            return DataBase.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        }

        public void RegisterAccount(string Email, string Password)
        {
            DataBase.Add(new User() { Email = Email, Password = Password });
        }

        public void SetNickName(Guid UserId, string Nick)
        {
            DataBase.Where(x => x.Id == UserId).FirstOrDefault().NickName = Nick;
        }



        //Project operations
        public void RemoveProject(Guid userId, string title)
        {
            DataBase.Where(x => x.Id == userId).FirstOrDefault().Projects?.RemoveAll(x => x.Title == title);
        }

        public void EditProject(Guid userId, string title, string updatedTitle, string updatedDescription)
        {
            Project prj = DataBase.Where(x => x.Id == userId).FirstOrDefault().Projects.Where(x => x.Title == title).FirstOrDefault();
            if (prj != null)
            {
                prj.Title = updatedTitle;
                prj.Description = updatedDescription;
            }
        }

        public void AddNewProject(Guid userId, string title, string description)
        {
            User usr = DataBase.Where(x => x.Id == userId).FirstOrDefault();
            if (usr != null)
            {
                usr.Projects.Add(new Project() { Title = title, Description = description });
            }
        }




        //Step operations
        public void AddStep(Guid userId, string projectTitle, string stepTitle, string stepDescription)
        {
            Project prj = DataBase.Where(x => x.Id == userId).FirstOrDefault().Projects.Where(x => x.Title == projectTitle).FirstOrDefault();
            if (prj != null)
            {
                prj.Steps.Add(new Step() { Title = stepTitle, Description = stepDescription, Completed = false });
            }
        }

        public void EditStep(Guid userId, string projectTitle, string stepTitle, string updatedStepTitle, string updatedStepDescription)
        {
            Project prj = DataBase.Where(x => x.Id == userId).FirstOrDefault().Projects.Where(x => x.Title == projectTitle).FirstOrDefault();
            if (prj != null)
            {
                Step step = prj.Steps.Where(x => x.Title == stepTitle).FirstOrDefault();
                if (step != null)
                {
                    step.Title = updatedStepTitle;
                    step.Description = updatedStepDescription;
                    step.Completed = false;
                }
            }
        }

        public void RemoveStep(Guid userId, string projectTitle, string stepTitle)
        {
            Project prj = DataBase.Where(x => x.Id == userId).FirstOrDefault().Projects.Where(x => x.Title == projectTitle).FirstOrDefault();
            if (prj != null)
            {
                Step step = prj.Steps.Where(x => x.Title == stepTitle).FirstOrDefault();
                if (step != null)
                {
                    prj.Steps.Remove(step);
                }
            }
        }

        public void SetStepStatus(Guid userId, string projectTitle, string stepTitle, bool isDone)
        {
            Project prj = DataBase.Where(x => x.Id == userId).FirstOrDefault().Projects.Where(x => x.Title == projectTitle).FirstOrDefault();
            if (prj != null)
            {
                Step step = prj.Steps.Where(x => x.Title == stepTitle).FirstOrDefault();
                if (step != null)
                {
                    step.Completed = isDone;
                }
            }
        }
    }
}
