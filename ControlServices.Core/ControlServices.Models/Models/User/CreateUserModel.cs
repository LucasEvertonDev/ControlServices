using ControlServices.Core.Models.Models.Base;

namespace ControlServices.Core.Models.Models.User;

public class CreateUserModel : BaseModel
{
    public CreateUserModel()
    {
        this.Role = "admin";
    }

    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
