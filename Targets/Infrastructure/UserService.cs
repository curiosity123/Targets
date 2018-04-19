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
            Users = new List<IUser>() { new User() { NickName = "lukasz", Email = "luki@p.pl", Id = Guid.NewGuid(), Password = "testowe haslo" } };
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
           return (from x in Users where x.Email == Email select x).FirstOrDefault();
        }

    }
}
