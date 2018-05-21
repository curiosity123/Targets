using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TargetsClient
{
    public class EditPrjDto
    {
        public Token token { get; set; }
        public Guid PrjectId { get; set; }
        public string UpdatedTitle { get; set; }
        public string UpdatedDescription { get; set; }

    }
}
