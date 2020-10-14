using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaninApi.Core.Enums;
using PaninApi.Core.Models;

namespace PaninApi.Core.Dtos
{
    public class BasicOrderDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("creationDate")]
        public string CreationDate { get; set; }
        
        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }
        
        [JsonPropertyName("coffeeShopId")]
        public int CoffeeShopId { get; set; }
        
        [JsonPropertyName("items")]
        public virtual IEnumerable<OrderItem> Items { get; set; }
        
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
        
        [JsonPropertyName("studentClass")]
        public StudentClassDto Class { get; set; }
    }
}