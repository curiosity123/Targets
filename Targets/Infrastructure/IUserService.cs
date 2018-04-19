using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        IUser Get(string Email, string Password);
        void RegisterAccount(string Email, string NickName, string Password);
        void DeleteAccount(string Email, string Password);


    }
}
