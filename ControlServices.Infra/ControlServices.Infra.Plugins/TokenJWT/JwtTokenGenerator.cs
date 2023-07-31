using ControlServices.Core.IContracts.Services.Token;
using ControlServices.Core.Models.Models.Token;
using ControlServices.Infra.Plugins.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlServices.Infra.Plugins.TokenJWT;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public JwtTokenGenerator(IConfiguration configuration,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<TokenModel> GenerateTokenJWT(string login)
    {
        var expiration = DateTime.UtcNow.AddHours(double.Parse(_configuration["Jwt:ExpireHours"] ?? ""));

        var user = await _userManager.FindByNameAsync(login);

        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? "");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = new SigningCredentials(
               new SymmetricSecurityKey(key),
               SecurityAlgorithms.HmacSha256Signature
            ),
            IssuedAt = DateTime.UtcNow,
            Expires = expiration,
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(nameof(ApplicationUser.Id), user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            })
        };

        var roles = await _userManager.GetRolesAsync(user);

        roles.ToList().ForEach(role => tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role)));

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new TokenModel()
        {
            TokenJWT = tokenHandler.WriteToken(token),
            Expiration = expiration,
        };
    }
}
