using Azure;
using ControlServices.API.Middlewares;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.Requests;
using ControlServices.Core.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ControlServices.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly ICreateUsersService _createUserService;
        private readonly ILoginService _loginService;

        public AuthController (ICreateUsersService createUserService,
                ILoginService loginService
            )
        {
            this._createUserService = createUserService;
            this._loginService = loginService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseDTO<TokenModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] RequestDTO<CreateUsersModel> requestDTO)
        {
            var response = new ResponseDTO<TokenModel>()
            {
                Content = await _createUserService.ExecuteAsync(requestDTO.Body),
                Sucess = true
            };

            return Ok(response);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseDTO<TokenModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] RequestDTO<LoginModel> requestDTO)
        {
            var response = new ResponseDTO<TokenModel>()
            {
                Content = await _loginService.ExecuteAsync(requestDTO.Body),
                Sucess = true
            };

            return Ok(response);
        }
    }
}
