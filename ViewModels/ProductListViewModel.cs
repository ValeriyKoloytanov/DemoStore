using System.Collections.Generic;
using DemoStore.Models;

namespace DemoStore.ViewModels
{
  public class ProductListViewModel
  {
    public IEnumerable<Product> Products { get; set; }
    public string CurrentCategory { get; set; }
  }
}