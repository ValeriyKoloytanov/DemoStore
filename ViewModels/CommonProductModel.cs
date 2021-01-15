using System.Collections.Generic;
using DemoStore.Models;

namespace DemoStore.ViewModels
{
    public class CommonViewModel 
    {  public Product product { get; set; }
        public IEnumerable<Product> Products  { get; set; }
    }
}