using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain.Interfaces
{
    public interface IStep
    {
        string Title { get; set; }
        string Description { get; set; }
        bool IsDone { get; set; }
    }
}
