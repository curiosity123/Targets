using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Interfaces;

namespace Targets.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IUser Get(string Email, string Password);
        void RegisterAccount(string Email, string Password);
        void SetNickName(Guid UserId, string Nick);
        void DeleteAccount(string Email, string Password);
    }
}
