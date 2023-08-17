using ControlServices.Core.Models.IModels;
using ControlServices.Core.Models.Models.Base;
using System.ComponentModel;

namespace ControlServices.Core.Models.Models.User;

public class LoginModel : BaseModel
{
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue("lucas")]
    public string Login { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue("123456")]
    public string Password { get; set; }
}
