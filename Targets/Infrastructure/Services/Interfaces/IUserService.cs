using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;

namespace Targets.Controllers
{
    public interface IUserService
    {
        Task<User> GetAccount(Guid UserId);
    }
}