using System;
using System.Collections.Generic;
using PaninApi.Core.Enums;

namespace PaninApi.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public virtual User User { get; set; }
        
        public string UserId { get; set; }
        
        public string CreationDate { get; set; }
        
        public OrderStatus Status { get; set; }
        
        public CoffeeShop CoffeeShop { get; set; }
        
        public int CoffeeShopId { get; set; }
        
        public virtual IEnumerable<OrderItem> Items { get; set; }
        
        public string Notes { get; set; }
        
        public StudentClass Class { get; set; }
    }
}