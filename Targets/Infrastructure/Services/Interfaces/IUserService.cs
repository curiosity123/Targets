using Targets.Domain.Implementations;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        User Get(Token token);
        void RegisterAccount(Token token);
        void DeleteAccount(Token token);

    }
}
