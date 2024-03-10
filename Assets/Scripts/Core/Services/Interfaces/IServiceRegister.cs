using twinkocat.Core.Bootstrap.Interfaces;

namespace twinkocat.Core.Services.Interfaces
{
    public interface IServiceRegister
    {
        void RegisterService<T>(IBootstrapper scope) where T : IService, new();
        void UnRegisterService<T>() where T : IService;
    }
}