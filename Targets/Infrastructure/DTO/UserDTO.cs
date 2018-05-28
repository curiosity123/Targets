using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Implementations;

namespace Targets.Domain.DTO
{
    public class UserDTO 
    {
        public Guid Id { get ; set; }
        public string NickName { get; set; }
        public List<Project> Projects { get; set; }
       }
}
