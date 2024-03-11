// file GlobalBootstrapper.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using twinkocat.Core.Bootstrap;
using twinkocat.Core.Services.Interfaces;
using twinkocat.Gameplay.Global.Services;

#endregion

namespace twinkocat.Gameplay.Global
{
    public class GlobalBootstrapper : Bootstrapper
    {
        public override void RegisterServices(IServiceRegister serviceRegister)
        {
            serviceRegister.RegisterService<ApplicationLoadService>(this);
            serviceRegister.RegisterService<PauseService>(this);
        }
    }
}