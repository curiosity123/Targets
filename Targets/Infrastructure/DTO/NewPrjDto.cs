using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Infrastructure.DTO
{
    public class NewPrjDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
