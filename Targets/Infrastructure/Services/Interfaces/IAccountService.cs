using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Infrastructure.DTO;

namespace Targets.Controllers
{
    public interface IAccountService
    {
        Task<TokenDTO> GetToken(Credentials credentials);
        Task<IActionResult> RegisterAccount(Credentials credentials);
        Task<IActionResult> DeleteAccount(Guid UserId);
    }
}