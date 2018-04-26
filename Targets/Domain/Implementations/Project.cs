using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain.Implementations
{
    public class Project
    {

        public Project()
        {
             
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public List<Step> Steps { get; set; }
           }
}
