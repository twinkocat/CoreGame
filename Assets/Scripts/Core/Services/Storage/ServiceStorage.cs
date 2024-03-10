﻿using System.Collections.Generic;
using twinkocat.Core.Services.Interfaces;

namespace twinkocat.Core.Services.Storage
{
    public class ServiceStorage : ServiceStorageBase, IServiceGetter, ICollection<IService>
    {
        private readonly HashSet<IService> _entries = new();

        public int     Count         => _entries.Count;
        public bool    IsReadOnly    => false;

        public override IEnumerator<IService> GetEnumerator() => _entries.GetEnumerator();

        public T Get<T>() where T : IService
        {
            foreach (var service in _entries)
            {
                if (service is not T tService) continue;
                
                return tService;
            }

            return default(T);
        }

        public override void Add(IService service) => _entries.Add(service);

        public bool Remove(IService item) => _entries.Remove(item);

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
        
        
        public override void Clear() => _entries.Clear();

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
        public bool Contains(IService item) => _entries.Contains(item);

        public void CopyTo(IService[] array, int arrayIndex) => _entries.CopyTo(array, arrayIndex);
    }
}