using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain
{
    public interface IProject
    {
        string Title { get; set; }
        string Description { get; set; }
        bool Completed { get; set; }
        List<IStep> Steps { get; set; }

    }
}
