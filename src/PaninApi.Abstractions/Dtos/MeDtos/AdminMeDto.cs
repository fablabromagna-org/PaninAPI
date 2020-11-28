using PaninApi.Abstractions.Enums;

namespace PaninApi.Abstractions.Dtos.MeDtos
{
    public class AdminMeDto : MeDto
    {
        public AdminMeDto()
        {
            AccountType = Enums.AccountType.Admin;
        }
    }
}