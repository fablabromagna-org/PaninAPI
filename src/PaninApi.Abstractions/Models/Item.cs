using System.Collections.Generic;
using PaninApi.Abstractions.Enums;

namespace PaninApi.Abstractions.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public ItemCategory Category { get; set; }

        public ItemModifier Modifiers { get; set; }

        public int Price { get; set; }

        public int Availability { get; set; }

        public virtual CoffeeShop CoffeeShop { get; set; }

        public int CoffeeShopId { get; set; }
        
        public virtual IEnumerable<OrderItem> Orders { get; set; }
    }
}