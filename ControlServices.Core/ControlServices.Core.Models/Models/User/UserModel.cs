using ControlServices.Core.Models.IModels;
using ControlServices.Core.Models.Models.Base;
using System.Text.Json.Serialization;

namespace ControlServices.Core.Models.Models.User;

public class UserModel : BaseModel
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
