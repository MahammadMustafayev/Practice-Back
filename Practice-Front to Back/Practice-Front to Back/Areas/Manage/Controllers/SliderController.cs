using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Practice_Front_to_Back.DAL;
using Practice_Front_to_Back.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice_Front_to_Back.Utilities.Extension;
using System.IO;

namespace Practice_Front_to_Back.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _env ;
        private AppDbContext  _context { get;  }
        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (slider.Photo.Checksize(250))
            {
                ModelState.AddModelError("Photo", "This value than more 200kb");
                return View();
            }
            if (!slider.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "Maybe have been error");
                return View();
            }
            slider.Image = await slider.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath,"image","bg-images"));
            await _context.AddAsync(slider);
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            Slider existslider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            if (existslider == null) return NotFound();
            existslider.Title1 = slider.Title1;
            existslider.Title2 = slider.Title2;
            existslider.Description = slider.Description;
            existslider.Image = slider.Image;
            existslider.Order = slider.Order;
            existslider.Price = slider.Price;
            existslider.RedirectUrl = slider.RedirectUrl;
            existslider.RedirectUrlText = slider.RedirectUrlText;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            if (slider == null) return NotFound();
            if (slider.Id == id)

            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
