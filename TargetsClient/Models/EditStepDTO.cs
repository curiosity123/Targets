using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TargetsClient
{
    public class EditStepDTO
    {
        public Guid ProjectId { get; set; }
        public Guid StepId { get; set; }
        public string UpdatedStepTitle { get; set; }
        public string UpdatedStepDescription { get; set; }
    }
}
