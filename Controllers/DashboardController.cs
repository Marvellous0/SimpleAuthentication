using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthentication.Models;
using SimpleAuthentication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleAuthentication.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        
        public DashboardController()
        {
            
        }

        public IActionResult Index()
        {

            //Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            //User user = _userRepository.FindUserById(userId);

            //DashboardVM vm = new DashboardVM
            //{
            //    User = user
            //};

            return View();
        }
    }
}
