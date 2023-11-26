using DataInfo.Data.Entitys;
using DataInfo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HW_Web__1_MVC_.Helpers;

namespace HW_Web__1_MVC_.Controllers
{
    public class FavoritesController : Controller
    {
        public readonly _AutoDbContext adc;
        public FavoritesController(_AutoDbContext adc)
        {
            this.adc = adc;
        }
        public IActionResult Index()
        {
            List<int> idList = null;
            idList = HttpContext.Session.Get<List<int>>("favorites_list");

            List<Auto> autos = new List<Auto>();

            if (idList != null)
                autos = adc.Autos.Where(a => idList.Contains(a.Id)).ToList();

            return View(autos);
        }
        public IActionResult AddToFavorite(int id)
        {
            List<int>? idList = HttpContext.Session.Get<List<int>>("favorites_list");
            if (idList == null)
            {
                idList = new List<int>();
            }
            idList.Add(id);
            HttpContext.Session.Set("favorites_list", idList);


            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveFromFavorites(int id, string controllerName)
        {
            List<int>? idList = HttpContext.Session.Get<List<int>>("favorites_list");
            if (idList != null)
                idList.Remove(id);
            HttpContext.Session.Set("favorites_list", idList);

            return RedirectToAction("Index", $"{controllerName}");
        }

    }
}
