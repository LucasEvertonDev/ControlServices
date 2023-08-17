using ControlServices.Core.Models.Models.User;
using ControlServices.Core.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ControlServices.API.Infrastructure.Documentation
{
    public class LoginExample : IExamplesProvider<RequestDTO<LoginModel>>
    {
        public RequestDTO<LoginModel> GetExamples()
        {
            return new RequestDTO<LoginModel> { Body = new LoginModel { Login ="lucas", Password = "123456" } };
        }
    }
}
