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
    public class GenreController : Controller
    {
        private AppDbContext _context { get;  }
        public GenreController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Genres.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (genre == null) return NotFound();
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            if (genre == null) return BadRequest();
            return View(genre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            Genre existgenre = _context.Genres.FirstOrDefault(x => x.Id == genre.Id);
            if (existgenre == null)
            {
                ModelState.AddModelError("", "Incorrect");
            }
            existgenre.GenreName = genre.GenreName;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Genre genre = _context.Genres.Find(id);
            if (genre == null)
            {
                ModelState.AddModelError("", "Incorrect");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
