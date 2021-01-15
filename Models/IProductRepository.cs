using System.Collections.Generic;

namespace DemoStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> FeaturedProducts { get;}
        Product GetProductById(int productId);
    }
}
