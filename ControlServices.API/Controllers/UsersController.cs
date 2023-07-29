using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.Models.Constants;
using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlServices.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ISearchUsersService _searchUsersService;

        public UsersController(ISearchUsersService searchUsersService)
        {
            this._searchUsersService = searchUsersService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(typeof(ResponseDTO<List<SearchUsersModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {
            var response = new ResponseDTO<List<SearchUsersModel>>()
            {
                Content = await _searchUsersService.ExecuteAsync(),
                Sucess = true
            };
            return Ok(response);
        }
    }
}
