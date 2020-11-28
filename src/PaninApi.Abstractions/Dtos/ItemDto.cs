using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaninApi.Abstractions.Enums;

namespace PaninApi.Abstractions.Dtos
{
    public class ItemDto
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("picture")] public string Picture { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("category")] public ItemCategory Category { get; set; }

        [JsonPropertyName("modifiers")] public IEnumerable<string> Modifiers { get; set; }

        [JsonPropertyName("price")] public int Price { get; set; }

        [JsonPropertyName("availability")] public int Availability { get; set; }
    }
}