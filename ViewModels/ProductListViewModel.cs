using System.Collections.Generic;
using DemoStore.Models;

namespace DemoStore.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Ammaval { get; set; }

        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }

        public List<string> Properities { get; set; }
    }
}