namespace PaninApi.Core.Models
{
    public class Barman : BaseUser
    {
        public virtual CoffeeShop CoffeeShop { get; set; }
        
        public int CoffeShopId { get; set; }
    }
}