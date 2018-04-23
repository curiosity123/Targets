using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Domain.Interfaces;

namespace Targets.Infrastructure
{
    public class UserService : IUserService
    {

        List<IUser> Users;

        public UserService()
        {
            Users = new List<IUser>() { new User() { NickName = "lukasz", Email = "lukasz@gmail.com", Id = Guid.NewGuid(), Password = "pass" } };
        }

        public void DeleteAccount(string Email, string Password)
        {
            Users.Remove(Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault());
        }

        public IUser Get(string Email, string Password)
        {
            return Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
        }

        public void RegisterAccount(string Email, string Password)
        {
            Users.Add(new User() { Email = Email, Password = Password });
        }

        public void SetNickName(Guid UserId, string Nick)
        {
            Users.Where(x => x.Id == UserId).FirstOrDefault().NickName = Nick;
        }
    }
}
