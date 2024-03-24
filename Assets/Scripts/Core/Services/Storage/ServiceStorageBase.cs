// file ServiceStorageBase.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections;
using System.Collections.Generic;
using twinkocat.Core.Services.Interfaces;

#endregion

namespace twinkocat.Core.Services.Storage
{
    public abstract class ServiceStorageBase : IServiceStorage, IEnumerable<IService>
    {
        public abstract IEnumerator<IService> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public abstract void Add(IService service);
        public abstract bool Remove<T>() where T : IService;
        public abstract void Clear();

        public void Add(object obj)
        {
            if (obj is not IService service) return;

            Add(service);
        }

        public void Add<T>() where T : IService, new()
        {
            Add(new T());
        }
    }
}