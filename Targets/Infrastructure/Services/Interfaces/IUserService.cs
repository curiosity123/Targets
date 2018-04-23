using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;
using Targets.Domain.Interfaces;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        IUser Get(string Email, string Password);
        Guid GetId(string Email, string Password);
        void RegisterAccount(string Email, string Password);
        void DeleteAccount(string Email, string Password);
        void SetNickName(Guid UserId, string Nick);

    }
}
