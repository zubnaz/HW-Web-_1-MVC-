using DataInfo.Data.Entitys;
using DataInfo.Data;
using HW_Web__1_MVC_.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace HW_Web__1_MVC_.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public readonly _AutoDbContext adc;
        private string userId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        public OrdersController(_AutoDbContext adc)
        {
            this.adc = adc;
        }
        public IActionResult Index()
        {
            return View(adc.Orders.Include(o => o.Auto).Where(o => o.UserId == userId).ToList());
        }
        public IActionResult Buy(int id, string controllerName)
        {
            var order = new Order()
            {
                AutoId = id,
                UserId = userId,
                Date = DateTime.Now
            };
            List<int>? idList = HttpContext.Session.Get<List<int>>("favorites_list");
            if (idList != null)
                idList.Remove(id);
            HttpContext.Session.Set("favorites_list", idList);
            adc.Orders.Add(order);
            adc.SaveChanges();
            return RedirectToAction("Index", $"{controllerName}");
        }
    }
}
