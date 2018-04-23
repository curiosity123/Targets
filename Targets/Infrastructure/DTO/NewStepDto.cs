using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Infrastructure.DTO
{
    public class NewStepDto
    {
        public Guid UserId { get; set; }
        public string ProjectTitle { get; set; }
        public string StepTitle { get; set; }
        public string StepDescription { get; set; }
    }
}
