using System.Linq;
using DemoStore.Models;
using DemoStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Dashboard : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public Dashboard(IProductRepository productRepository, ICategoryRepository categoryRepository,
            AppDbContext appDbContext, IWebHostEnvironment hostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _appDbContext = appDbContext;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            int count_users = _appDbContext.Users.Count();
            int count_pr = _appDbContext.Products.Count();
            int Orders_count = _appDbContext.Products.Count();

            return View(new BasicStatsViewModel
            {
                Usercount = count_users,
                Productscount = count_pr
            });
        }
    }
}