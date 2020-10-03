using PaninApi.Core.Enums;

namespace PaninApi.Core.Dtos.MeDtos
{
    public abstract class MeDto
    {
        public AccountType AccountType { get; protected set; }
    }
}