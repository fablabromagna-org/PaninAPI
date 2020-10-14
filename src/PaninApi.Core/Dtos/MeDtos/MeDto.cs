using System.Text.Json.Serialization;
using PaninApi.Core.Enums;

namespace PaninApi.Core.Dtos.MeDtos
{
    public abstract class MeDto
    {
        [JsonPropertyName("accountType")] public AccountType AccountType { get; protected set; }
    }
}