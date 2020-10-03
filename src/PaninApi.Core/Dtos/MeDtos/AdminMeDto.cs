using PaninApi.Core.Enums;

namespace PaninApi.Core.Dtos.MeDtos
{
    public class AdminMeDto : MeDto
    {
        public AdminMeDto()
        {
            AccountType = AccountType.Admin;
        }
    }
}