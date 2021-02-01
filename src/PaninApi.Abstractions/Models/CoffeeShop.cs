using System.Collections.Generic;

namespace PaninApi.Abstractions.Models
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
        
        public static bool operator ==(CoffeeShop a, CoffeeShop b)
        {
            return a?.Equals(b) ?? false;
        }

        public static bool operator !=(CoffeeShop a, CoffeeShop b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if (obj is CoffeeShop coffeeShop)
            {
                Equals(coffeeShop);
            }
            
            return false;
        }

        public bool Equals(CoffeeShop coffeeShop)
        {
            if (coffeeShop is null)
            {
                return false;
            }

            if (ReferenceEquals(this, coffeeShop))
            {
                return true;
            }

            if (Id != coffeeShop.Id)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}