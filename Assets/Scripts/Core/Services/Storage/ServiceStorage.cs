// file ServiceStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections.Generic;
using twinkocat.Core.Services.Interfaces;

#endregion

namespace twinkocat.Core.Services.Storage
{
    public class ServiceStorage : ServiceStorageBase, IServiceGetter, ICollection<IService>
    {
        private readonly HashSet<IService> _entries = new();

        public int Count => _entries.Count;
        public bool IsReadOnly => false;

        public override IEnumerator<IService> GetEnumerator()
        {
            return _entries.GetEnumerator();
        }

        public override void Add(IService service)
        {
            _entries.Add(service);
        }

        public bool Remove(IService item)
        {
            return _entries.Remove(item);
        }


        public override void Clear()
        {
            _entries.Clear();
        }

        public bool Contains(IService item)
        {
            return _entries.Contains(item);
        }

        public void CopyTo(IService[] array, int arrayIndex)
        {
            _entries.CopyTo(array, arrayIndex);
        }

        public T Get<T>() where T : IService
        {
            foreach (var service in _entries)
            {
                if (service is not T tService) continue;

                return tService;
            }

            return default;
        }

        public bool TryGet<T>(out T service) where T : IService
        {
            service = Get<T>();

            return service != null;
        }

        public override bool Remove<T>()
        {
            var itemToRemove = default(T);

            foreach (var service in _entries)
            {
                if (service is not T tService) continue;

                itemToRemove = tService;
                break;
            }

            return _entries.Remove(itemToRemove);
        }

        public bool Contains<T>() where T : IService
        {
            var contains = false;
            foreach (var variable in _entries)
            {
                contains = variable is T;

                if (contains) break;
            }

            return contains;
        }
    }
}