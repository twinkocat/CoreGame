// file ApplicationLoadService.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using twinkocat.Core;
using twinkocat.Core.Services;
using twinkocat.Core.Services.Interfaces;
using twinkocat.Gameplay.GameStates;
using twinkocat.Gameplay.GameSubStates;

#endregion

namespace twinkocat.Gameplay.Global.Services
{
    public class ApplicationLoadService : IService
    {
        public void OnSetup() => ApplicationEvents.OnApplicationLoad += OnApplicationLoad;

        private void OnApplicationLoad()
        {
            GameInstance.Instance.SetState(new MenuState());
            GameInstance.Instance.SetSubState(new PlaySubState());
            
            ServiceLocator.GetInstance().UnRegisterService<ApplicationLoadService>();
        }

        public void Dispose() => ApplicationEvents.OnApplicationLoad -= OnApplicationLoad;
    }
}