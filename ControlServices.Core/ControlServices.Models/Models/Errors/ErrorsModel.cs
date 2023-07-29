using ControlServices.Core.Models.IModels;
using ControlServices.Core.Models.Models.Base;

namespace ControlServices.Core.Models.Models.Errors;

public class ErrorsModel : BaseModel
{
    public ErrorsModel() { }

    public string[] Messages { get; set; }

    public ErrorsModel(params string[] message)
    {
        this.Messages = message;
    }
}
