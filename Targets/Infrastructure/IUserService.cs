using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        IUser Get(string Email);
        IEnumerable<IUser> GetAll();
        void Create(string Email);
        void Delete(string Email);

    }
}
