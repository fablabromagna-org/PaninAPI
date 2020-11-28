using System.Text.Json.Serialization;
using PaninApi.Abstractions.Enums;

namespace PaninApi.Abstractions.Dtos.MeDtos
{
    public abstract class MeDto
    {
        [JsonPropertyName("accountType")] public AccountType AccountType { get; protected set; }
    }
}