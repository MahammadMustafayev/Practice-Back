using Microsoft.AspNetCore.Mvc;
using Practice_Front_to_Back.DAL;
using Practice_Front_to_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AuthorController : Controller
    {
        private AppDbContext _context { get;  }
        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (author == null)
            {
                ModelState.AddModelError("", "Incorrect");
            }
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                ModelState.AddModelError("", "Incorrect");
            }
            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            Author exstauth = _context.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (exstauth == null) return NotFound();
            exstauth.AuthName = author.AuthName;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Author author = _context.Authors.Find(id);
            if (author == null)
            {
                ModelState.AddModelError("", "Incorrect");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
