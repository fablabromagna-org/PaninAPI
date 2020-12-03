using Microsoft.AspNetCore.Mvc;

namespace PaninApi.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]/{action=Index}")]
    [Consumes("application/json")]
    public abstract class BaseApiController : Controller
    {
    }
}