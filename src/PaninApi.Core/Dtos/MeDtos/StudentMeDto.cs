using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaninApi.Core.Enums;

namespace PaninApi.Core.Dtos.MeDtos
{
    public class StudentMeDto : MeDto
    {
        public StudentMeDto()
        {
            AccountType = AccountType.User;
        }

        [JsonPropertyName("isResponsible")] public bool IsResponsible { get; set; }

        [JsonPropertyName("inProgressOrders")] public IEnumerable<BasicOrderDto> InProgressOrders { get; set; }
        
        [JsonPropertyName("coffeeShops")] public IEnumerable<int> CoffeeShops { get; set; }
    }
}