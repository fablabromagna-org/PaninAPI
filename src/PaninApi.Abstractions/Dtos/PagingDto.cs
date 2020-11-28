using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaninApi.Abstractions.Dtos
{
    public class PagingDto<TValue> where TValue : class
    {
        [JsonPropertyName("total")] public int Total { get; set; }

        [JsonPropertyName("count")] public int Count { get; set; }

        [JsonPropertyName("currPage")] public int CurrentPage { get; set; }

        [JsonPropertyName("prevPage")] public string PrevPage { get; set; }

        [JsonPropertyName("nextPage")] public string NextPage { get; set; }

        [JsonPropertyName("values")] public IEnumerable<TValue> Values { get; set; }
    }
}