using Microsoft.AspNetCore.Mvc;

namespace GroceryStore2.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}