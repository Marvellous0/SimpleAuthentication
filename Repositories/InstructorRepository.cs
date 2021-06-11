using SimpleAuthentication.Context;
using SimpleAuthentication.Interface;
using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AuthDBContext _dbContext;

        public InstructorRepository(AuthDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Instructor Add(Instructor instructor)
        {
            _dbContext.Instructors.Add(instructor);
            _dbContext.SaveChanges();
            return instructor;
        }
    }
}
