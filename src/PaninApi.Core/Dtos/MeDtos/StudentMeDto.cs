using PaninApi.Core.Enums;

namespace PaninApi.Core.Dtos.MeDtos
{
    public class StudentMeDto : MeDto
    {
        public StudentMeDto()
        {
            AccountType = AccountType.User;
        }
        
        
    }
}