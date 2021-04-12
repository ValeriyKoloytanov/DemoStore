using System.Collections.Generic;
using DemoStore.Models;

namespace DemoStore.ViewModels
{
    public class BasicStatsViewModel
    {
        public int Usercount { get; set; }
        public int Productscount { get; set; }
        public int  Orderscount { get; set; }
        public decimal  TotalSoldSum { get; set; }
        public IEnumerable<Product> Products { get; set; }


    }
}