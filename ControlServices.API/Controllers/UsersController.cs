using ControlServices.API.Infrastructure.Attributes;
using ControlServices.API.Infrastructure.Helpers;
using ControlServices.Core.IContracts.Services.User;
using ControlServices.Core.Models.Constants;
using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.Responses;
using ControlServices.Core.Models.RouteParams.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControlServices.API.Controllers;

public class UsersController : BaseController
{
    private readonly ISearchUsersService _searchUsersService;

    public UsersController(ISearchUsersService searchUsersService)
    {
        this._searchUsersService = searchUsersService;
    }

    /// <summary>
    /// Carrega todos os usuários
    /// </summary>
    /// <returns></returns>
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


    /// <summary>
    ///  Carrega usuários com filtros
    /// </summary>
    /// <param name="usersParams"></param>
    /// <returns></returns>
    [HttpGetParams<UsersParams>()]
    [ProducesResponseType(typeof(ResponseDTO<List<SearchUsersModel>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get([FromQuery] UsersParams usersParams)
    {
        var response = new ResponseDTO<List<SearchUsersModel>>()
        {
            Content = await _searchUsersService.ExecuteAsync(usersParams),
            Sucess = true
        };
        return Ok(response);
    }
}
