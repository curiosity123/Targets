using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;

namespace Targets.Infrastructure
{
    public class UserService : IUserService
    {

        IEnumerable<IUser> Users;

        public UserService()
        {
            Users = new List<IUser>() { new User { Email = "test1@t.pl", NickName = "test1" }, new User { Email= "test2@t.pl", NickName= "test2" }  };
        }


        public void Create(string Email)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Email)
        {
            throw new NotImplementedException();
        }

        public IUser Get(string Email)
        {
            return (from x in Users where Email == x.Email select x).FirstOrDefault();
        }

        public IEnumerable<IUser> GetAll()
        {
            return Users;
        }
    }
}
