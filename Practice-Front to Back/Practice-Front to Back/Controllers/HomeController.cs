using Microsoft.AspNetCore.Mvc;
using Practice_Front_to_Back.DAL;
using Practice_Front_to_Back.Models;
using Practice_Front_to_Back.ViewModel;
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
            HomeVM homeVM = new HomeVM()
            {
                Sliders = _context.Sliders.ToList(),
                Features = _context.Features.ToList()
            }; 
            return View(homeVM);
        }
        
    }
}
