using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string NickName { get; set; }
        string Password { get; set; }
        List<IProject> Projects { get; set; }

    }
}
