using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Infrastructure.Services;

namespace Targets.Infrastructure.DTO
{
    public class NewPrjDto
    {
        public Token token { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
