using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Domain.Interfaces;

namespace Targets.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {

        List<IUser> DataBase;

        public InMemoryUserRepository()
        {
            DataBase = new List<IUser>() { new User() { NickName = "lukasz", Email = "lukasz@gmail.com", Id = Guid.NewGuid(), Password = "pass" } };
        }

        public void DeleteAccount(string Email, string Password)
        {
            DataBase.Remove(DataBase.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault());
        }

        public IUser Get(string Email, string Password)
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
    }
}
