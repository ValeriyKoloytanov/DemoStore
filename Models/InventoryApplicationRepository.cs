using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DemoStore.Models
{
    public class InventoryApplicationRepository: IInventoryApplicationRepository
    {
        private readonly AppDbContext _appDbContext;

            public InventoryApplicationRepository(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            public IEnumerable<InventoryApplication> Applications
            {
                  get
                  {
                      return _appDbContext.InventoryApplications
                          .OrderBy(p => p.InventoryApplicationId)
                          .Include(c => c.Ammount).ToList();
                  }
            }
        }
}