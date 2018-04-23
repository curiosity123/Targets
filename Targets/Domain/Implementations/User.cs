using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targets.Domain.Interfaces;

namespace Targets.Domain.Implementations
{
    public class User : IUser
    {
        public User()
        {
          
        }
       

        public Guid Id { get ; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set ; }
        public List<IProject> Projects { get; set; }
    }
}
