namespace PaninApi.Core.Models
{
    public class BarmanCoffeeShop
    {
        public virtual CoffeeShop CoffeeShop { get; set; }
        
        public int CoffeeShopId { get; set; }
        
        public virtual Barman Barman { get; set; }
        
        public string BarmanId { get; set; }
    }
}