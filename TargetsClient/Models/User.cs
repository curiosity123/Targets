using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetsClient
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            Projects = new List<Project>();
        }


        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Role { get; set; } = "user";
        public DateTime CreartedAt { get; set; }
        public List<Project> Projects { get; set; }
    }
}
