using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
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

        public async Task DeleteAccount(Token token)
        {
           await repo.DeleteAccountAsync(token);
        }

        public async Task<User> GetAsync(Token token)
        {
            return await repo.GetAsync(token);
        }

        public async Task RegisterAccount(Token token)
        {
           await repo.RegisterAccountAsync(token);
        }

    }
}
