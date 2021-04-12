using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DemoStore.Models
{
    public class InventoryApplication
    {
        public int InventoryApplicationId { get; set; }
        public int  Ammount { get; set; }
        [BindNever] [ScaffoldColumn(false)] public DateTime OrderPlaced { get; set; }
    }
}
