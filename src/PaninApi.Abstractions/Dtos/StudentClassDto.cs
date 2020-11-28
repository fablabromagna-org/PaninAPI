using System.Text.Json.Serialization;

namespace PaninApi.Abstractions.Dtos
{
    public class StudentClassDto
    {
        [JsonPropertyName("class")] public int Class { get; set; }

        [JsonPropertyName("section")] public string Section { get; set; }

        [JsonPropertyName("display")] public string Display => $"{Class} {Section}";
    }
}