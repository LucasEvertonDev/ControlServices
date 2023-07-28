using Azure.Core;
using ControlServices.Core.IContracts.Repositorys.User;
using ControlServices.Core.Models.Models.User;
using ControlServices.Infra.Data.Migrations;
using ControlServices.Infra.Utils.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ControlServices.Infra.Data.Contexts.Repositorys.User;

public class CreateUserRepository : ICreateUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    public CreateUserRepository(UserManager<IdentityUser> userManager)
    {
        this._userManager = userManager;
    }

    public async Task<CreateUserModel> CreateAsync(CreateUserModel userModel)
    {
        var user = await _userManager.FindByEmailAsync(userModel.Email);
 
        if (user != null)
        {
            throw new BusinessException("Já existe um usuário cadastrado para o email informado");
        }

        var result = await _userManager.CreateAsync(new IdentityUser
        {
            UserName = userModel.UserName,
            Email = userModel.Email,
            PhoneNumber = userModel.PhoneNumber,
        }, userModel.Password);

        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.Select(x => x.Description).ToList());
        }

        await _userManager.AddToRoleAsync(user, userModel.Role);

        return userModel;
    }

}
