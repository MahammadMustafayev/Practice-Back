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
    public class FeatureController : Controller
    {
        public FeatureController(AppDbContext context)
        {
            _context = context;
        }

        private AppDbContext _context { get; }

        public IActionResult Index()
        {
            List<Feature> features = _context.Features.ToList();
            return View(features);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Feature feat = _context.Features.FirstOrDefault(f=>f.Id == id);
            if (feat == null) return NotFound();
            return View(feat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Feature feature)
        {
            Feature exist = _context.Features.FirstOrDefault(f=>f.Id == feature.Id);
            exist.Title = feature.Title;
            exist.Subtitle = feature.Subtitle;
            exist.Icon = feature.Icon;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Feature feature = _context.Features.Find(id);
            if (feature == null) return NotFound();
            feature.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
