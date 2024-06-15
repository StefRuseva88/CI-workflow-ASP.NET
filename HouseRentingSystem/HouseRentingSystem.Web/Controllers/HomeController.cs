using HouseRentingSystem.Web.Models;
using HouseRentingSystem.Web.Models.Home;
using HouseRentingSystem.Services.Houses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using static HouseRentingSystem.Web.Areas.Admin.AdminConstants;

namespace HouseRentingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService houses;
        public HomeController(IHouseService houses)
            => this.houses = houses;

        public IActionResult Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            
            var houses = this.houses.LastThreeHouses();
            return View(houses);
        }

        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}