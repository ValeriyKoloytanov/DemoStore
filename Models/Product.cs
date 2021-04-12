using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Ammaval { get; set; }

        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public int Sold { get; set; }

        public List<string> Properities { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
    }
}