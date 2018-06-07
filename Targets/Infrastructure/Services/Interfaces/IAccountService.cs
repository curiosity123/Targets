using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Infrastructure.DTO;

namespace Targets.Controllers
{
    public interface IAccountService
    {
        Task<TokenDTO> LoginAsync(Credentials credentials);
        Task RegisterAccount(Credentials credentials);
        Task DeleteAccount(Guid UserId);
    }
}