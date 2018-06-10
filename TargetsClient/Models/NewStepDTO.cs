using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetsClient
{
    public class NewStepDTO
    {
        public Guid ProjectId { get; set; }
        public string StepTitle { get; set; }
        public string StepDescription { get; set; }
    }
}
