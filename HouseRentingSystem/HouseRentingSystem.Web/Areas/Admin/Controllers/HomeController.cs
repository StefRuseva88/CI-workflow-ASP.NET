using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Areas.Admin.Controllers
{
    public class HomeController 
        : AdminController
    {
        public IActionResult Index()
            => View();
    }
}
