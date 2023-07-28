using ControlServices.API.Middlewares;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControlServices.API.Controllers
{
    [ApiController]
    [CultureMiddleware]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ICreateUserService _createUserService;

        public AuthController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> _signInManager,
            ICreateUserService createUserService)
        {
            this._userManager = userManager;
            this._signInManager = _signInManager;
            this._createUserService = createUserService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> CreateUser([FromBody] RequestDTO<CreateUserModel> requestDTO)
        {
            return Ok(await _createUserService.ExecuteAsync(requestDTO.Model));
        }
    }
}
