using DataInfo.Data.Entitys;
using DataInfo.Data;
using HW_Web__1_MVC_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HW_Web__1_MVC_.Helpers;

namespace HW_Web__1_MVC_.Controllers
{
    public class HomeController : Controller
    {
        public readonly _AutoDbContext adc;
        public HomeController(_AutoDbContext adc)
        {
            this.adc = adc;
        }

        public IActionResult Index()
        {
            return View(adc);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}