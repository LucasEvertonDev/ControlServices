
using ControlServices.Core.Models.IModels;

namespace ControlServices.Core.Models.Responses;

public class ResponseDTO<TModel>
{
	public ResponseDTO()
	{
		Content = Activator.CreateInstance<TModel>();
		Sucess = true;
	}

	public TModel Content { get; set; }

	public bool Sucess { get; set; }
}

