using ControlServices.Core.Models.Models.Base;
using ControlServices.Core.Models.Models.User.Base;

namespace ControlServices.Core.Models.Models.User;

public class CreateUsersModel : UserModel
{
    public CreateUsersModel()
    {
        this.Role = "Administrador";
    }
}
