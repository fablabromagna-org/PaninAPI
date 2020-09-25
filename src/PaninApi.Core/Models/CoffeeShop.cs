using System.Collections.Generic;

namespace PaninApi.Core.Models
{
    public class CoffeeShop
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public virtual IEnumerable<Item> Items { get; set; }
        
        public virtual IEnumerable<Barman> Barmen { get; set; }
        
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}