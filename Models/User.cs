using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Models
{
    public class User : BaseEntity
    {
        
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string HashSalt { get; set; }

        public Role Role { get; set; }

        public Student Student { get; set; }

        public Instructor Instructor { get; set; }


    }
}
