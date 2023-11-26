using DataInfo.Data.Entitys;
using DataInfo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HW_Web__1_MVC_.Model;
using HW_Web__1_MVC_.Helpers;

namespace HW_Web__1_MVC_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AutoController : Controller
    {
        public readonly _AutoDbContext adc;
        private readonly IFileServices fileServices;

        public AutoController(_AutoDbContext adc,IFileServices fileServices)
        {
            this.adc = adc;
            this.fileServices = fileServices;
        }
        public void Colors()
        {
            this.ViewBag.Colors = new SelectList(adc.Colors.ToList(), "Id", "ColorName");
        }
        public IActionResult Index()
        {
            return View(adc);
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            Colors();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CreateAutoModel autoCreate)
        {
            if (!ModelState.IsValid) { Colors(); return View(autoCreate); }

            var auto = new Auto()
            {
                Mark = autoCreate.Mark,
                Model = autoCreate.Model,
                Price = autoCreate.Price,
                Year = autoCreate.Year,
                ColorId = autoCreate.ColorId,
                Image = await fileServices.SaveAutoImage(autoCreate.Image)
            };
            
            adc.Autos.Add(auto);
            adc.SaveChanges();

            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult Information(int id, string controllerName)
        {
            this.ViewBag.String = controllerName;
            var car = adc.Autos.Include(c => c.Color);
            foreach (var item in car)
            {
                if (item.Id == id) return View(item);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            adc.Autos.Remove(adc.Autos.Find(id));
            adc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = adc.Autos.Include(c => c.Color);
            Colors();
            foreach (var item in car)
            {
                if (item.Id == id) return View(item);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Auto auto)
        {
            if (!ModelState.IsValid) { Colors(); return View(auto); }


            adc.Autos.Update(auto);
            adc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
