using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_Front_to_Back.DAL;
using Practice_Front_to_Back.Models;
using Practice_Front_to_Back.Utilities.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (product == null) return BadRequest();
            if (product.Photo.Checksize(350))
            {
                ModelState.AddModelError("Photo", "This value than more 350 kb");
                return View();
            }
            if (product.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "Maybe have been error");
                return View();
            }
            product.ProductImages = new List<ProductImages>();
            _context.Products.Add(product);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            Product existproduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existproduct == null) return BadRequest();
            existproduct.Genre = product.Genre;
            existproduct.Author = product.Author;
            existproduct.CostPrice = product.CostPrice;
            existproduct.Desc = product.Desc;
            existproduct.DiscountPrice = product.DiscountPrice;
            existproduct.InfoText = product.InfoText;
            existproduct.IsFeatured = product.IsFeatured;
            existproduct.IsNew = product.IsNew;
            existproduct.Name = product.Name;
            existproduct.Photo = product.Photo;
            existproduct.ProductImages = product.ProductImages;
            existproduct.SalePrice = product.SalePrice;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null) return BadRequest();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
