using ControlServices.Core.Models.IModels;
using ControlServices.Core.Models.Models.Base;

namespace ControlServices.Core.Models.Models.User;

public class LoginModel : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
}
