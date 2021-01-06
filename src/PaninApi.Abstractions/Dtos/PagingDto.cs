using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaninApi.Abstractions.Dtos
{
    public class PagingDto<TValue> where TValue : class
    {
        [JsonPropertyName("values")] public IEnumerable<TValue> Values { get; set; }
    }
}