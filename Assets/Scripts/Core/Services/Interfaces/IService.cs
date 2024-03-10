using System;

namespace twinkocat.Core.Services.Interfaces
{
    public interface IService : IDisposable
    {
        void OnSetup();
    }
}