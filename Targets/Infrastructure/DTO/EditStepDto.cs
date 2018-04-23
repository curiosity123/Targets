using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Infrastructure.DTO
{
    public class EditStepDto
    {
        public Guid UserId { get; set; }
        public string ProjectTitle { get; set; }
        public string StepTitle { get; set; }
        public string UpdatedStepTitle { get; set; }
        public string UpdatedStepDescription { get; set; }
    }
}
