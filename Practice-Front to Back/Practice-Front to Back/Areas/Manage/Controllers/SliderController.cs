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
    public class SliderController : Controller
    {
        private AppDbContext _context { get;  }
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( Slider slider)
        {
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(p => p.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            Slider esxistslider = _context.Sliders.FirstOrDefault(s => s.Id == slider.Id);
            if (esxistslider == null) return NotFound();

            esxistslider.Title1 = slider.Title1;
            esxistslider.Title2 = slider.Title2;
            esxistslider.Description = slider.Description;
            esxistslider.Order = slider.Order;
            esxistslider.Image = slider.Image;
            esxistslider.RedirectUrl = slider.RedirectUrl;
            esxistslider.RedirectUrlText = slider.RedirectUrlText;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Slider delete = _context.Sliders.Find(id);
            if (delete == null) return NotFound();
            _context.Sliders.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
