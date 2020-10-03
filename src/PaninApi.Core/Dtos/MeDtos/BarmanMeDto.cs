using System.Collections.Generic;
using PaninApi.Core.Enums;

namespace PaninApi.Core.Dtos.MeDtos
{
    public class BarmanMeDto : MeDto
    {
        public BarmanMeDto()
        {
            AccountType = AccountType.Barman;
        }
        
        public IEnumerable<int> CoffeShopIds { get; set; }
    }
}