using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaninApi.Abstractions.Enums;

namespace PaninApi.Abstractions.Dtos.MeDtos
{
    public class BarmanMeDto : MeDto
    {
        public BarmanMeDto()
        {
            AccountType = Enums.AccountType.Barman;
        }

        [JsonPropertyName("coffeeShops")] public IEnumerable<int> CoffeShopIds { get; set; }
    }
}