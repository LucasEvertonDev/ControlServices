using Microsoft.AspNetCore.Mvc;

namespace ControlServices.Core.Models.RouteParams.Users;

public class UsersParams
{
    public UsersParams()
    {
        Email = null;
        PhoneNumber = null;
    }

    [FromRoute(Name = "email")]
    public string Email { get; set; }
    [FromRoute(Name = "phonenumber")]
    public long? PhoneNumber { get; set; }
}
