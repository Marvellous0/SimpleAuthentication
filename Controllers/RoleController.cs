using Microsoft.AspNetCore.Mvc;
using SimpleAuthentication.Context;
using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Controllers
{
    public class RoleController : Controller
    {
        private readonly AuthDBContext _context;

        public RoleController(AuthDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddRole()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddRole(string name)
        {
            Guid id = Guid.NewGuid();

            Role role = new Role
            {
                Id = id,
                Name = name.ToLower()
            };

            _context.Roles.Add(role);
            _context.SaveChanges();

            return View();
        }
    }
}
