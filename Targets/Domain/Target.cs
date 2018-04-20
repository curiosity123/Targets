using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain
{
    public class Target:ITarget
    {

        public Target()
        {
             
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
