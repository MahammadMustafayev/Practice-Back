using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
