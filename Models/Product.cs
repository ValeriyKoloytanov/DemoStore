
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace DemoStore.Models
{
    public class Product
    {    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int  Ammaval { get; set; }

        public byte[] Image { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }

        public List<string> Properities { get; set; }

        public virtual Category Category { get; set; }
    }
}
