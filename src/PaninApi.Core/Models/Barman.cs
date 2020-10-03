using System.Collections.Generic;

namespace PaninApi.Core.Models
{
    public class Barman : BaseUser
    {
        public virtual IEnumerable<BarmanCoffeeShop> CoffeeShops { get; set; }
    }
}