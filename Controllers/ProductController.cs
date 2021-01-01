using System;
using GroceryStore2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GroceryStore2.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly AppDbContext _appDbContext;
    
    public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,AppDbContext appDbContext)
    {
      _productRepository = productRepository;
      _categoryRepository = categoryRepository;
      _appDbContext = appDbContext;
    }

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

    public ViewResult ManageContent()
    {
      IEnumerable<Product> products;
      products = _productRepository.Products.OrderBy(p => p.ProductId);


      return View(new CommonViewModel
        {
          Products = products
          

        }
      );
    }

    public async Task<IActionResult> Get_Product(int id)
    {
      Product product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);
      return View(new CommonViewModel
      {
        product = product

      }
      );
    }


    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
  _appDbContext.Entry(product).State = EntityState.Modified; 
  _appDbContext.Entry(product).CurrentValues.SetValues(product);
  _appDbContext.Entry(product).Property("Price").IsModified = true;
     _appDbContext.Entry(product).Property("Name").IsModified = true;
     _appDbContext.Entry(product).Property("Description").IsModified = true;
     _appDbContext.SaveChanges();
      return View("Views/Dashboard/Index.cshtml");
    }

  }
}
