using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Interface
{
    public interface IUserService
    {

        public void RegisterUser(string email, string fullname, string password, string userType);

        public User LoginUser(string email, string password);
    }
}
