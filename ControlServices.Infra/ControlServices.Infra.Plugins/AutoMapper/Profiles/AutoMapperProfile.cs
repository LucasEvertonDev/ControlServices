using AutoMapper;
using ControlServices.Core.Domain.Entities;
using ControlServices.Core.Models.Models.Clients;
using ControlServices.Core.Models.Models.Clients.Base;

namespace ControlServices.Infra.Plugins.AutoMapper.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        ConvertDomainToModel();

        ConvertModelToDomain();
    }


    public void ConvertDomainToModel()
    {
        CreateMap<Client, ClientModel>();
    }

    public void ConvertModelToDomain()
    {
        CreateMap<CreateClientsModel, Client>();
        CreateMap<ClientModel, Client>();
    }
}
