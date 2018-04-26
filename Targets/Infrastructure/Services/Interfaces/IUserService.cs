using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Implementations;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        User Get(string Email, string Password);
        void RegisterAccount(string Email, string Password);
        void DeleteAccount(string Email, string Password);
        void SetNickName(Guid UserId, string Nick);
    }
}
