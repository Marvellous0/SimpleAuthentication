using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Models
{
    public abstract class Details
    {

        public User User { get; set; }

        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }


    }
}
