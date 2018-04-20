using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;

namespace Targets.Infrastructure
{
    public class UserService : IUserService
    {

        List<IUser> Users;

        public UserService()
        {
            Users = new List<IUser>();// { new User() { NickName = "lukasz", Email = "luki@p.pl", Id = Guid.NewGuid(), Password = "testowe haslo" } };
        }

        public void RegisterAccount(string Email, string NickName, string Password)
        {
            if (Users.Where(x => x.Email == Email).Count() == 0)
            {
                User usr = new User() { Id = Guid.NewGuid(), Email = Email, NickName = NickName, Password = Password };
                Users.Add(usr);
            }
        }

        public void DeleteAccount(string Email, string Password)
        {
            Users.RemoveAll(x => x.Email == Email && x.Password == Password);
        }

        public IUser Get(string Email, string Password)
        {
            return (from x in Users where x.Email == Email && x.Password == Password select x).FirstOrDefault();
        }

        public void AddNewProject(string Email, string Password, string Title, string Description)
        {

            IUser usr = (from x in Users where x.Email == Email select x).FirstOrDefault();
            if (usr != null)
                usr.Projects.Add(new Project() { Title = Title, Description = Description });

        }

        public void EditProject(string Email, string Password, string Title, string UpdatedTitle, string UpdatedDescription)
        {
            IUser usr = (from x in Users where x.Email == Email select x).FirstOrDefault();
            if (usr != null)
            {
                IProject prj = (from x in usr.Projects where x.Title == Title select x).FirstOrDefault();
                if (prj != null)
                {
                    prj.Title = UpdatedTitle;
                    prj.Description = UpdatedDescription;
                }
}
        }

        public void RemoveProject(string Email, string Password, string Title)
        {
            IUser usr = (from x in Users where x.Email == Email select x).FirstOrDefault();
            if (usr != null)
                usr.Projects.RemoveAll(x => x.Title == Title);
        }

        public void AddStep(string Email, string Password, string ProjectTitle, string StepTitle, string StepDescription)
        {
            throw new NotImplementedException();
        }

        public void RemoveStep(string Email, string Password, string ProjecttTitle, string StepTitle)
        {
            throw new NotImplementedException();
        }

        public void EditStep(string Email, string Password, string ProjectTitle, string StepTitle, string UpdatedStepTitle, string UpdatedStepDescription)
        {
            throw new NotImplementedException();
        }
    }
}
