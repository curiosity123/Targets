using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targets.Domain
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
        public byte[] Photo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
