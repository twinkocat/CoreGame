// file IServiceGetter.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Core.Services.Interfaces
{
    public interface IServiceGetter
    {
        T Get<T>() where T : IService;
        bool TryGet<T>(out T service) where T : IService;
    }
}