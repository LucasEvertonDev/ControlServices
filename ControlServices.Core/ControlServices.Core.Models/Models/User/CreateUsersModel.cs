using ControlServices.Core.Models.Models.Base;

namespace ControlServices.Core.Models.Models.User;

public class CreateUsersModel : UserModel
{
    public CreateUsersModel()
    {
        this.Role = "Administrador";
    }
}
