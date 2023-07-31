using Microsoft.AspNetCore.Identity;

namespace ControlServices.Infra.Plugins.Identity;

public class ApplicationUser : IdentityUser
{
    public int Situation { get; set; } = 1;
}
