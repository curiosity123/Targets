using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.DTO
{
    public class EditProjectDTO
    {
        public Guid ProjectId { get; set; }
        public string UpdatedTitle { get; set; }
        public string UpdatedDescription { get; set; }

    }
}
