using System.Collections.Generic;

namespace PaninApi.Core.Models
{
    public class CoffeeShop
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public virtual IEnumerable<Item> Items { get; set; }
        
        public virtual IEnumerable<BarmanCoffeeShop> Barmen { get; set; }
        
        public virtual IEnumerable<Order> Orders { get; set; }
        
        public virtual School School { get; set; }
        
        public int SchoolId { get; set; }
    }
}