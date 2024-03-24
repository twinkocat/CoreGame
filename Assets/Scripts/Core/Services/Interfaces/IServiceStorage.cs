// file IServiceStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Core.Services.Interfaces
{
    public interface IServiceStorage
    {
        void Add(IService service);
        bool Remove<T>() where T : IService;
        void Clear();
    }
}