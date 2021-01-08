using Microsoft.AspNetCore.Mvc;

namespace GroceryStore2.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}