using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Interface
{
    public interface IUserRepository
    {

        public User AddUser(User user);

        public User FindUserByEmail(string email);

        public Role FindRole(string name);
    }
}
