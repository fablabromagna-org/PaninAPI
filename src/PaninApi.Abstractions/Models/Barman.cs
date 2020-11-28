using System.Collections.Generic;

namespace PaninApi.Abstractions.Models
{
    public class Barman : BaseUser
    {
        public virtual IEnumerable<BarmanCoffeeShop> CoffeeShops { get; set; }
    }
}