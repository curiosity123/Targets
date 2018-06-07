using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Controllers;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Repositories;
using Targets.Infrastructure.Services.Interfaces;

namespace Targets.Infrastructure.Services
{
    public class AccountService : IAccountService
    {


        IRepository repo;
        IJwtHandler _JwtHandler;

        public AccountService(IRepository _repo, IJwtHandler handler)
        {
            repo = _repo;
            _JwtHandler = handler;
        }



        public Task DeleteAccount(Guid UserId)
        {
            throw new NotImplementedException();
        }


        public Task RegisterAccount(Credentials credentials)
        {
            return repo.RegisterAccountAsync(credentials);
        }

        public async Task<TokenDTO> Login(Credentials credentials)
        {
           var u = await repo.GetAccountAsync(credentials.Email, credentials.Password);

            if (u != null)
            {
                var jwt = _JwtHandler.CreateToken(u.Id, u.Role);

                return new TokenDTO
                {
                    Token = jwt.Token,
                    Expires = jwt.Expires,
                    Role = u.Role
                };
            }
            else
                return null;
        }
    }
}
