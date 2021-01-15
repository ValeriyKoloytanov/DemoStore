using System.Collections.Generic;

namespace DemoStore.Models
{
    public interface ICategoryRepository
    {
      IEnumerable<Category> GetCategories();
    }
}
