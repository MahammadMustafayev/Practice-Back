using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_Front_to_Back.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public  IActionResult Index()
        {
            return  PartialView("_ProductPartial", _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .ToList()
                );
        }
    }
}
