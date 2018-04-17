using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain;

namespace Targets.Infrastructure
{
    public interface IUserService
    {
        IUser Get(Guid Id);
        IEnumerable<IUser> GetAll();
        void Create(IUser user);
        void Delete(Guid Id);

    }
}
