using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        Task<User> GetAsync(Token token);
        Task RegisterAccount(Token token);
        Task DeleteAccount(Token token);

    }
}
