using System.Collections.Generic;

namespace DemoStore.Models
{
    public interface IInventoryApplicationRepository
    {
        IEnumerable<InventoryApplication> Applications{ get; }

    }
}