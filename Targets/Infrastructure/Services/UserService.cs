using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Controllers;
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

        public Task<User> GetAccount(Guid UserId)
        {
            return  repo.GetAccountAsync(UserId);
        }


    }
}
