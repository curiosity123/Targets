using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TargetsClient
{
    public class SetStateStepDTO
    {
            public Guid StepId { get; set; }
            public bool IsDone { get; set; }
    }
}
