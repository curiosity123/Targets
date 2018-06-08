using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetsClient
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
    }
}
