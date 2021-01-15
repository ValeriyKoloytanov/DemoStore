using DemoStore.Models;
using DemoStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    public class HomeController : Controller
    {
      private readonly IProductRepository _productRepository;

      public HomeController(IProductRepository productRepository)
      {
        _productRepository = productRepository;
      }

      public ViewResult Index()
      {
        var homeViewModel = new HomeViewModel
        {
          FeaturedProducts = _productRepository.FeaturedProducts
        };

        return View(homeViewModel);
      }
    }
}
