using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain
{
    public interface ITarget
    {
        string Title { get; set; }
        string Description { get; set; }
        bool Completed { get; set; }

    }
}
