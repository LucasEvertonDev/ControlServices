using Microsoft.AspNetCore.Mvc;

namespace ControlServices.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
    }
}
