using Microsoft.AspNetCore.Authorization;

namespace PaninApi.WebApi.Controllers
{
    [Authorize]
    public abstract class BaseAuthApiController : BaseApiController
    {
        
    }
}