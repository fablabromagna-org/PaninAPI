using PaninApi.Core.Models;

namespace PaninApi.Core.Dtos.Services
{
    public interface IUserService
    {
        BaseUser GetOrCreate(BaseUser user);
    }
}