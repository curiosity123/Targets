using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Interfaces;

namespace Targets.Domain.Implementations
{
    public class Project:IProject
    {

        public Project()
        {
             
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public List<IStep> Steps { get; set; }
    }
}
