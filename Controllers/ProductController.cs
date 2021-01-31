using System;
using DemoStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
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
    private readonly IWebHostEnvironment webHostEnvironment;
    public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository ,AppDbContext appDbContext,IWebHostEnvironment hostEnvironment)
    {
      _productRepository = productRepository;
      _categoryRepository = categoryRepository;
      _appDbContext = appDbContext;
      webHostEnvironment = hostEnvironment;  

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

    private string UploadedFile(ProductViewModel model)  
    {  
      string filePath = null;  

      if (model.ProfileImage != null)  
      {  
        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "img");   
         filePath = Path.Combine(uploadsFolder, model.ImageUrl);  
        using (var fileStream = new FileStream(filePath, FileMode.Create))  
        {  
          model.ProfileImage.CopyTo(fileStream);  
        }  
      }  
      return filePath;  
    }  
    [HttpPost]
    public  async Task<IActionResult> Edit(Product product)
    {
      _appDbContext.Entry(product).State = EntityState.Modified;
      _appDbContext.Entry(product).CurrentValues.SetValues(product);
      _appDbContext.Entry(product).Property("Price").IsModified = true;
      _appDbContext.Entry(product).Property("Description").IsModified = true;
      _appDbContext.Entry(product).Property("Name").IsModified = true;
      _appDbContext.Entry(product).Property("IsFeatured").IsModified = true;
      _appDbContext.Entry(product).Property("CategoryId").IsModified = true;  
      _appDbContext.Entry(product).Property("Properities").IsModified = true;
      await  _appDbContext.SaveChangesAsync();
      return RedirectToAction("ManageContent");
    }

    public IActionResult Create()
    {
      SelectList categories = new SelectList(_appDbContext.Categories, "CategoryId", "CategoryName");
      ViewBag.Categories = categories;
      return View();
    }
    public  async Task<IActionResult>  new_property(int id )
    
    { 
      Product product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);

      _appDbContext.Entry(product).State = EntityState.Modified;
        _appDbContext.Entry(product).CurrentValues.SetValues(product);
        _appDbContext.Entry(product).Property("Properities").IsModified = true;
        product.Properities.Add("");
        await  _appDbContext.SaveChangesAsync();
       return  RedirectToAction("ManageContent");
    }
    public  async Task<IActionResult>  delete_prop(int id,int i )
    
    { 
      Product product = _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);

      _appDbContext.Entry(product).State = EntityState.Modified;
      _appDbContext.Entry(product).CurrentValues.SetValues(product);
      _appDbContext.Entry(product).Property("Properities").IsModified = true;
      product.Properities.RemoveAt(i);
      await  _appDbContext.SaveChangesAsync();
      return  RedirectToAction("ManageContent");
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
 
      _appDbContext.Products.Add(product);

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
