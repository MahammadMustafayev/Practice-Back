using Microsoft.AspNetCore.Mvc;
using Practice_Front_to_Back.DAL;
using Practice_Front_to_Back.Models;
using System.Collections.Generic;
using System.Linq;

namespace Practice_Front_to_Back.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get;  }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            
            return View(sliders);
        }
    }
}
