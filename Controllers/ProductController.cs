using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Models;
using DemoStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.ViewNotResolved

namespace DemoStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IInventoryApplicationRepository _inventoryRepository;


        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,
            AppDbContext appDbContext,InventoryApplicationRepository inventoryRepository, IWebHostEnvironment hostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _inventoryRepository = inventoryRepository;
            _appDbContext = appDbContext;
            webHostEnvironment = hostEnvironment;
        }
        [Route("Products/{productId}")]
        public IActionResult ProductDetail(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        public ViewResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.Products.OrderBy(p => p.Name);
                currentCategory = "All";
            }
            else
            {
                {
                    products = _productRepository.Products.Where(p => p.Category.CategoryName == category)
                        .OrderBy(p => p.Name);
                    currentCategory = _categoryRepository.GetCategories()
                        .FirstOrDefault(c => c.CategoryName == category)
                        ?.CategoryName;
                }
            }

            return View(new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }
        [Route("ManageContent")]
        public ViewResult ManageContent()
        {
            IEnumerable<Product> products;
            products = _productRepository.Products.OrderBy(p => p.ProductId);


            return View( new CommonViewModel
                {
                    Products = products
                }
            );
        }

        public ViewResult Inventory()
        {
            IEnumerable<Product> products;
            IEnumerable<InventoryApplication> inventoryApplications;
            inventoryApplications = _inventoryRepository.Applications.OrderBy(p => p.InventoryApplicationId);
            products = _productRepository.Products.OrderBy(p => p.ProductId);
            


            return View("Views/Suppliers/index.cshtml", new CommonViewModel
                {
                    Products = products,
                    applies = inventoryApplications

                }
            );
        }


        public async Task<IActionResult> Edit(int id)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);
            var categories = new SelectList(_appDbContext.Categories, "CategoryId", "CategoryName");
            ViewBag.Categories = categories;
            return View(new CommonViewModel
                {
                    product = product
                }
            );
        }


        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, CommonViewModel model)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == model.product.ProductId);
            var path = "/img/" + file.FileName;
            using (var fileStream = new FileStream(webHostEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var baseUrl = Request.GetTypedHeaders().Referer.ToString();
            _appDbContext.Entry(product).State = EntityState.Modified;
            _appDbContext.Entry(product).CurrentValues.SetValues(product);
            _appDbContext.Entry(product).Property("ImageUrl").IsModified = true;

            product.ImageUrl = path;
            await _appDbContext.SaveChangesAsync();
            return Redirect(baseUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            _appDbContext.Entry(product).State = EntityState.Modified;
            _appDbContext.Entry(product).CurrentValues.SetValues(product);
            _appDbContext.Entry(product).Property("Price").IsModified = true;
            _appDbContext.Entry(product).Property("Description").IsModified = true;
            _appDbContext.Entry(product).Property("Name").IsModified = true;
            _appDbContext.Entry(product).Property("SupplierId").IsModified = true;
            _appDbContext.Entry(product).Property("IsFeatured").IsModified = true;
            _appDbContext.Entry(product).Property("CategoryId").IsModified = true;
            _appDbContext.Entry(product).Property("Properities").IsModified = true;
            _appDbContext.Entry(product).Property("ImageUrl").IsModified = true;
            ;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("ManageContent");
        }

        public IActionResult Create()
        {
            var categories = new SelectList(_appDbContext.Categories, "CategoryId", "CategoryName");
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(Product product)
        {
            _appDbContext.Entry(product).State = EntityState.Modified;
            _appDbContext.Entry(product).CurrentValues.SetValues(product);
            _appDbContext.Entry(product).Property("Properities").IsModified = true;
            await _appDbContext.SaveChangesAsync();
            var baseUrl = Request.GetTypedHeaders().Referer.ToString();
            return Redirect(baseUrl);
        }

        public async Task<IActionResult> new_property(int id)

        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);

            _appDbContext.Entry(product).State = EntityState.Modified;
            _appDbContext.Entry(product).CurrentValues.SetValues(product);
            _appDbContext.Entry(product).Property("Properities").IsModified = true;
            if (product.Properities == null) product.Properities = new List<string>();

            product.Properities.Add("");
            await _appDbContext.SaveChangesAsync();
            var baseUrl = Request.GetTypedHeaders().Referer.ToString();
            return Redirect(baseUrl);
        }

        public async Task<IActionResult> delete_prop(int id, int i)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);

            _appDbContext.Entry(product).State = EntityState.Modified;
            _appDbContext.Entry(product).CurrentValues.SetValues(product);
            _appDbContext.Entry(product).Property("Properities").IsModified = true;
            product.Properities.RemoveAt(i);
            await _appDbContext.SaveChangesAsync();
            var baseUrl = Request.GetTypedHeaders().Referer.ToString();
            return Redirect(baseUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _appDbContext.Products.Add(product);
            if (product.ImageUrl == null) product.ImageUrl = "/img/No_picture.png";

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("ManageContent");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("ManageContent");
        }
    }
}