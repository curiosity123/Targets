using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Domain.Interfaces;
using Targets.Infrastructure.Repositories;

namespace Targets.Infrastructure
{
    public class UserService : IUserService
    {

        IUserRepository repo;

        public UserService(IUserRepository _repo)
        {
            repo = _repo;
        }

        public void DeleteAccount(string Email, string Password)
        {
            repo.DeleteAccount(Email, Password);
        }

        public IUser Get(string Email, string Password)
        {
            return repo.Get(Email, Password);
        }

        public void RegisterAccount(string Email, string Password)
        {
            repo.RegisterAccount(Email, Password);
        }

        public void SetNickName(Guid UserId, string Nick)
        {
            repo.SetNickName(UserId, Nick);
        }
    }
}
