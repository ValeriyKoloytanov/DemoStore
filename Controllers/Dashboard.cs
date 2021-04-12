using System.Collections.Generic;
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
        [Route("Dashboard")]
        public IActionResult Index()
        {
            int count_users = _appDbContext.Users.Count();
            int count_pr = _appDbContext.Products.Count();
            int Orders_count = _appDbContext.Orders.Count();
            decimal SumSold = _appDbContext.OrderDetails.Sum(order =>order.Price*order.Amount);

            IEnumerable<Product>  products = _productRepository.Products.OrderBy(p => p.Name);

            return View(new BasicStatsViewModel
            {
                Usercount = count_users,
                Productscount = count_pr,
                Orderscount = Orders_count,
                Products = products,
                TotalSoldSum = SumSold
                
            });
        }
    }
}