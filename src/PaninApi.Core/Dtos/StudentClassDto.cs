using System.Text.Json.Serialization;

namespace PaninApi.Core.Dtos
{
    public class StudentClassDto
    {
        [JsonPropertyName("class")] public int Class { get; set; }

        [JsonPropertyName("section")] public string Section { get; set; }
    }
}