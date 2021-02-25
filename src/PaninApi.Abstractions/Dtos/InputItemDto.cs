using System;
using System.Text.Json.Serialization;

namespace PaninApi.Abstractions.Dtos
{
    public class InputItemDto
    {
        [JsonPropertyName("item_id")] public Guid ItemId { get; set; }
        
        [JsonPropertyName("quantity")] public int Quantity { get; set; }
    }
}