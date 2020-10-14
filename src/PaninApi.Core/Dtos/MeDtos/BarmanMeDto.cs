using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaninApi.Core.Enums;

namespace PaninApi.Core.Dtos.MeDtos
{
    public class BarmanMeDto : MeDto
    {
        public BarmanMeDto()
        {
            AccountType = AccountType.Barman;
        }

        [JsonPropertyName("coffeeShops")] public IEnumerable<int> CoffeShopIds { get; set; }
    }
}