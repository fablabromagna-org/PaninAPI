using System;

namespace PaninApi.Core.Models
{
    public class OrderItem
    {
        public virtual Order Order { get; set; }
        
        public Guid OrderId { get; set; }
        
        public virtual Item Item { get; set; }
        
        public int ItemId { get; set; }
    }
}