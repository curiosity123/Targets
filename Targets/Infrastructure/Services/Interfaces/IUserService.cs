using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Infrastructure.DTO;

namespace Targets.Controllers
{
    public interface IUserService
    {
        Task<IActionResult> GetAccount(Guid UserId);
    }
}