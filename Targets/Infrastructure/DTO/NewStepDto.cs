using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.DTO
{
    public class NewStepDto
    {
        public Token token { get; set; }
        public Guid ProjectId { get; set; }
        public string StepTitle { get; set; }
        public string StepDescription { get; set; }
    }
}
