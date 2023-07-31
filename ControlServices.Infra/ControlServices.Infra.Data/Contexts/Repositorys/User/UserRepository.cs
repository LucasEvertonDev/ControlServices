using Azure.Core;
using ControlServices.Core.IContracts.Repositorys.User;
using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.RouteParams.Users;
using ControlServices.Infra.Plugins.Identity;
using ControlServices.Infra.Utils.Exceptions;
using ControlServices.Infra.Utils.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ControlServices.Infra.Data.Contexts.Repositorys.User;

public class UserRepository : ICreateUsersRepository, ILoginRepository, ISearchUsersRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRepository(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._roleManager = roleManager;
    }

    public async Task<CreateUsersModel> CreateAsync(CreateUsersModel userModel)
    {
        var user = await _userManager.FindByEmailAsync(userModel.Email);
 
        if (user != null)
        {
            throw new BusinessException(ResourceMessages.EmailAlreadyRegistered);
        }

        user = await _userManager.FindByNameAsync(userModel.Login);

        if (user != null)
        {
            throw new BusinessException(ResourceMessages.LoginAlreadRegistered);
        }

        var result = await _userManager.CreateAsync(new ApplicationUser
        {
            UserName = userModel.Login,
            Email = userModel.Email,
            PhoneNumber = userModel.PhoneNumber,
        }, userModel.Password);

        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.Select(x => x.Description).ToArray());
        }

        user = await _userManager.FindByNameAsync(userModel.Login);

        var role = await _roleManager.FindByNameAsync(userModel.Role);
        
        await _userManager.AddToRoleAsync(user, role.Name);

        return userModel;
    }

    public async Task<UserModel> LoginAsync(LoginModel loginModel)
    {
        var user = await _userManager.FindByNameAsync(loginModel.Login);
        if (user is null)
        {
            throw new BadCredentialsException();
        }

        if (!await _userManager.CheckPasswordAsync(user, loginModel.Password))
        {
            throw new BadCredentialsException();
        }

        return new UserModel
        {
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Login = user.UserName,
        };
    }

    public async Task<List<SearchUsersModel>> FindAllAsync(UsersParams usersParams)
    {
        return await _userManager.Users.AsNoTracking()
            .Where(user => (string.IsNullOrEmpty(usersParams.Email) || user.Email == usersParams.Email)
                && (!usersParams.PhoneNumber.HasValue || user.PhoneNumber.Contains(usersParams.PhoneNumber.Value.ToString()))
            )
            .Select(user => new SearchUsersModel
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Login = user.UserName,
                Id = user.Id
            })
            .ToListAsync();
    }
}
