using twinkocat.Core;
using twinkocat.Core.Services;
using twinkocat.Core.Services.Interfaces;

namespace twinkocat.Gameplay.Global.Services
{
    public class ApplicationLoadService : IService
    {
        public void OnSetup() => ApplicationEvents.OnApplicationLoad += OnApplicationLoad;

        private void OnApplicationLoad()
        {
            
            
            ServiceLocator.GetInstance().UnRegisterService<ApplicationLoadService>();
        }

        public void Dispose() => ApplicationEvents.OnApplicationLoad += OnApplicationLoad;
    }
}