using ControlServices.Core.Models.Models.User;

namespace ControlServices.Core.IContracts.Services.User;

public interface ISearchUsersService
{
    Task<List<SearchUsersModel>> ExecuteAsync();
}
