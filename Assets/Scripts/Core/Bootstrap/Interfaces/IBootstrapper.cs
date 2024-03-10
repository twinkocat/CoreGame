// file IBootstrapper.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using twinkocat.Core.Services.Interfaces;

#endregion

namespace twinkocat.Core.Bootstrap.Interfaces
{
    public interface IBootstrapper
    {
        void RegisterServices(IServiceRegister serviceRegister);
    }
}