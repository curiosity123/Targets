using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string NickName { get; set; }
        string Password { get; set; }
        IEnumerable<ITarget> Targets { get; set; }

    }
}
