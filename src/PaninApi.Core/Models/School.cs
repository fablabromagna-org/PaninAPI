using System.Collections.Generic;

namespace PaninApi.Core.Models
{
    public class School
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Tenant { get; set; }
        
        public virtual IEnumerable<CoffeeShop> CoffeeShops { get; set; }
    }
}