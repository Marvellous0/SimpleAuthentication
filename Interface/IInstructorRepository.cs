using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Interface
{
    public interface IInstructorRepository
    {

        public Instructor Add(Instructor instructor);

       
    }
}
