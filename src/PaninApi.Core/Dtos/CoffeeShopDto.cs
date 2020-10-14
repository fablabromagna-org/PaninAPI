using System.Text.Json.Serialization;

namespace PaninApi.Core.Dtos
{
    public class CoffeeShopDto
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }
    }
}