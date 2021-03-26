using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    public class ContactController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
                View();
        }
    }
}