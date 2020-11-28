using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaninApi.Abstractions.Enums;

namespace PaninApi.Abstractions.Dtos.MeDtos
{
    public class StudentMeDto : MeDto
    {
        public StudentMeDto()
        {
            AccountType = AccountType.Student;
        }

        [JsonPropertyName("inProgressOrders")] public IEnumerable<BasicOrderDto> InProgressOrders { get; set; }
        
        [JsonPropertyName("coffeeShops")] public IEnumerable<int> CoffeeShops { get; set; }
        
        [JsonPropertyName("studentClass")] public StudentClassDto StudentClass { get; set; }
    }
}