using twinkocat.Core.Bootstrap;
using twinkocat.Core.Services.Interfaces;
using twinkocat.Gameplay.Global.Services;

namespace twinkocat.Gameplay.Global
{
    public class GlobalBootstrapper : Bootstrapper
    {
        public override void RegisterServices(IServiceRegister serviceRegister)
        {
            serviceRegister.RegisterService<ApplicationLoadService>(this);
        }
    }
}