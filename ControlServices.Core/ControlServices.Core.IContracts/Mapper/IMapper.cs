namespace ControlServices.Core.IContracts.Mapper;

public interface IMapper
{
    TDestination Map<TDestination>(object source) where TDestination : class;
}
