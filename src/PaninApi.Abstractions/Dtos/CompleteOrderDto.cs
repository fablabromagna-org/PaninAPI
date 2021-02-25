using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaninApi.Abstractions.Dtos
{
    public class CompleteOrderDto
    {
        [JsonPropertyName("items")] public IEnumerable<InputItemDto> Items { get; set; }
    }
}