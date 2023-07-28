using Microsoft.Extensions.DependencyInjection;

namespace ControlServices.Infra.Utils.Utils
{
    public static class EngineContext
    {
        private static IServiceCollection _services { get; set; }

        public static void AddServices(IServiceCollection services)
        {
            _services = services;
        }

        public static TService GetService<TService>()
        {
            return _services.BuildServiceProvider().GetService<TService>();
        }

        public static object GetService(Type t)
        {
            try
            {
                return _services.BuildServiceProvider().GetService(t);
            }
            catch
            {
                return null;
            }
        }
    }
}
