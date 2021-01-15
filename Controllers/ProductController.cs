using DemoStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
// ReSharper disable Mvc.ViewNotResolved

namespace DemoStore.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly AppDbContext _appDbContext;
    public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository ,AppDbContext appDbContext)
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


      return View("Views/Dashboard/ManageContent.cshtml",new CommonViewModel
        {
          Products = products


        }
      );
    }


    public async Task<IActionResult> Edit(int id)
    {
      Product product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);
      SelectList categories = new SelectList(_appDbContext.Categories, "CategoryId", "CategoryName");
      ViewBag.Categories = categories;

      return View(new CommonViewModel
        {
          product = product,
        }
      );
    }

    [HttpPost]
    public   IActionResult Edit(Product product)
    {
      _appDbContext.Entry(product).State = EntityState.Modified;
      _appDbContext.Entry(product).CurrentValues.SetValues(product);
      _appDbContext.Entry(product).Property("Price").IsModified = true;
      _appDbContext.Entry(product).Property("Description").IsModified = true;
      _appDbContext.Entry(product).Property("Name").IsModified = true;
      _appDbContext.Entry(product).Property("IsFeatured").IsModified = true;
      _appDbContext.Entry(product).Property("CategoryId").IsModified = true;
      _appDbContext.SaveChangesAsync();
      return RedirectToAction("ManageContent");
    }

    public IActionResult Create()
    {
      SelectList categories = new SelectList(_appDbContext.Categories, "CategoryId", "CategoryName");
      ViewBag.Categories = categories;
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
      _appDbContext.Products.Add(product);
      product.ImageUrl= "~/img/fruits/"+  product.ImageUrl;

      await _appDbContext.SaveChangesAsync();
      return RedirectToAction("ManageContent");
    }

    public   async  Task<IActionResult> Delete(int id)
    {
      Product product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);
      _appDbContext.Products.Remove(product);
       await _appDbContext.SaveChangesAsync();
      return RedirectToAction("ManageContent");
    }
    
  }
}
