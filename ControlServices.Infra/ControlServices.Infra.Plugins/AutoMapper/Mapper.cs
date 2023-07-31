
using AutoMapper;

namespace ControlServices.Infra.Plugins.AutoMapper;

public class Mapper : ControlServices.Core.IContracts.Mapper.IMapper
{
    private readonly IMapper _mapper;

    public Mapper(IMapper mapper)
    {
        this._mapper = mapper;
    }

    public TDestination Map<TDestination>(object source) where TDestination : class
    {
        return _mapper.Map<TDestination>(source);
    }
}
