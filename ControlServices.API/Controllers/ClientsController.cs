using ControlServices.Core.IContracts.Services.Clients;
using ControlServices.Core.Models.Constants;
using ControlServices.Core.Models.Models.Clients;
using ControlServices.Core.Models.Models.Clients.Base;
using ControlServices.Core.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlServices.API.Controllers
{
    [ApiExplorerSettings(GroupName = "Cliente")]
    public class ClientsController : BaseController
    {
        private readonly ICreateClientsService _createClientsService;

        public ClientsController(ICreateClientsService createClientsService)
        {
            this._createClientsService = createClientsService;
        }

        /// <summary>
        /// Create client 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(typeof(ResponseDTO<ClientModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Post([FromBody] CreateClientsModel createClientsModel)
        {
            var response = new ResponseDTO<ClientModel>()
            {
                Content = await _createClientsService.ExecuteAsync(createClientsModel),
                Sucess = true
            };
            return Ok(response);
        }
    }
}
