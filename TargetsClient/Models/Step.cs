using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetsClient
{
    public class Step 
    {
        public Step()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
