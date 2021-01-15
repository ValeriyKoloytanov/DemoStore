using System.Collections.Generic;
using DemoStore.Models;

namespace DemoStore.ViewModels
{
  public class HomeViewModel
  {
    public IEnumerable<Product> FeaturedProducts { get; set; }
  }
}