using Microsoft.AspNetCore.Mvc;

namespace GroceryStore2.Controllers
{
    public class Dashboard : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}