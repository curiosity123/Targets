using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Controllers;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Repositories;

namespace Targets.Infrastructure.Services
{
    public class AccountService : IAccountService
    {


        IRepository repo;

        public AccountService(IRepository _repo)
        {
            repo = _repo;
        }



        public Task<IActionResult> DeleteAccount(Guid UserId)
        {
            throw new NotImplementedException();
        }


        public Task<IActionResult> RegisterAccount(Credentials credentials)
        {
            return await repo.RegisterAccountAsync(credentials);
        }

        public Task<TokenDTO> IAccountService.GetToken(Credentials credentials)
        {
                  return await new TokenDTO();
        }
    }
}
