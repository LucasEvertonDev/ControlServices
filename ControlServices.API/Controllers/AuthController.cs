using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.Models.Models.Errors;
using ControlServices.Core.Models.Models.Token;
using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.Requests;
using ControlServices.Core.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

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

        /// <summary>
        /// Rota para registar um usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST/register
        ///     {
        ///         "body": {
        ///              "login": "lucas",
        ///              "email": "lcseverton@gmail.com",
        ///              "phoneNumber": "+5532998313394",
        ///              "password": "123456",
        ///              "role": "Administrador"
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <response code="200">User is Registred</response>
        /// <returns></returns>
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

        /// <summary>
        /// Rota para logar com um usuário
        /// </summary>
        /// <param name="requestDTO"></param>
        /// <returns></returns>
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
