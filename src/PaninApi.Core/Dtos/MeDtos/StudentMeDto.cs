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

        [JsonPropertyName("inProgressOrders")] public PagingDto<BasicOrderDto> InProgressOrders { get; set; }

        [JsonPropertyName("pastOrders")] public PagingDto<BasicOrderDto> PastOrders { get; set; }
    }
}