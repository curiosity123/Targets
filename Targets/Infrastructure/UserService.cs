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

        public void Create(string Email, string NickName, string Password)
        {
            User usr = new User() { Id = Guid.NewGuid(), Email = Email, NickName = NickName, Password = Password };
            Users.Add(usr);
        }

        public void Delete(string Email)
        {
            Users.RemoveAll(x => x.Email == Email);  
        }

        public IUser Get(string Email)
        {
           return (from x in Users where x.Email == Email select x).FirstOrDefault();
        }

        public IEnumerable<IUser> GetAll()
        {
            return Users;
        }
    }
}
