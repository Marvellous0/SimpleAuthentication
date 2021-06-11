using Microsoft.EntityFrameworkCore;
using SimpleAuthentication.Context;
using SimpleAuthentication.Interface;
using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Repositories
{

    
    public class UserRepository : IUserRepository
    {

        private readonly AuthDBContext _dbContext;

        public UserRepository(AuthDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public Role FindRole(string name)
        {
            return  _dbContext.Roles.FirstOrDefault(r => r.Name.Equals(name));
        }

        public User FindUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email.Equals(email));
        }



        //public User FindUserById(Guid id)
        //{
        //    return users.FirstOrDefault(user => user.Id == id);
        //}


        //public User FindUserByEmail(string email)
        //{
        //    return users.FirstOrDefault(user => user.Email == email);
        //}

        //public User FindUserByEmailAndPassword(string email, string password)
        //{
        //    return users.FirstOrDefault(user => user.Email == email && user.Password==password);
        //}


    }
}
