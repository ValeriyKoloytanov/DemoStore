using System.Collections.Generic;
using DemoStore.Models;

namespace DemoStore.ViewModels
{
    public class ProfileViewModel
    {
        public AppUser User { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderDetail> Order_detail { get; set; }

        

    }
}