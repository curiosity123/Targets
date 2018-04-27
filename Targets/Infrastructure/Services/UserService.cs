using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Infrastructure.Repositories;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure
{
    public class UserService : IUserService
    {

        IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public void DeleteAccount(Token token)
        {
            repo.DeleteAccount(token);
        }

        public User Get(Token token)
        {
            return repo.Get(token);
        }

        public void RegisterAccount(Token token)
        {
            repo.RegisterAccount(token);
        }

        public void SetNickName(Token token, string Nick)
        {
            repo.SetNickName(token, Nick);
        }
    }
}
