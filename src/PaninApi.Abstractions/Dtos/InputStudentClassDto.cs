using System.Text.Json.Serialization;

namespace PaninApi.Abstractions.Dtos
{
    public class InputStudentClassDto
    {
        [JsonPropertyName("class")] public int Class { get; set; }

        [JsonPropertyName("section")] public string Section { get; set; }
    }
}