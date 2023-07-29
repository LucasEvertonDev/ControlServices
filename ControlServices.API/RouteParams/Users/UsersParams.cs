using ControlServices.Core.Models.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace ControlServices.API.RouteParams.Users;

public class UsersParams
{
    public UsersParams()
    {
        this.Email = null;
        this.PhoneNumber = null;
    }


    [FromRoute(Name = "email")]
    public string Email { get; set; }
    [FromRoute(Name = "phonenumber")]
    public string PhoneNumber { get; set; }
}
