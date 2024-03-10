using System;
using twinkocat.Core.Services.Interfaces;

namespace twinkocat.Core.Bootstrap.Interfaces
{
    public interface IBootstrapper
    {
        void RegisterServices(IServiceRegister serviceRegister);
    }
}