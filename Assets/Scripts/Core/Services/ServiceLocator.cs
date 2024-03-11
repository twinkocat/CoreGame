// file ServiceLocator.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections.Generic;
using twinkocat.Core.Bootstrap.Interfaces;
using twinkocat.Core.Services.Interfaces;
using twinkocat.Core.Services.Storage;
using twinkocat.Core.Utilities;
using UnityEngine;

#endregion

namespace twinkocat.Core.Services
{
    public class ServiceLocator : LazySingleton<ServiceLocator, IServiceGetter>, IServiceGetter, IServiceRegister
    {
        private readonly Dictionary<IBootstrapper, ServiceStorage> _serviceStorages = new();


        public void CreateStorage(IBootstrapper scope)
        {
            if (!_serviceStorages.TryAdd(scope, new ServiceStorage())) return;
            
            scope.RegisterServices(this);
        }

        public void DeleteStorage(IBootstrapper scope)
        {
            if (!_serviceStorages.ContainsKey(scope)) return;

            foreach (var service in _serviceStorages[scope])
                service.Dispose();
            
            _serviceStorages[scope].Clear();
            _serviceStorages.Remove(scope);
        }

        public void Setup(IBootstrapper scope)
        {
            if (!_serviceStorages.ContainsKey(scope)) return;

            foreach (var service in _serviceStorages[scope])
                service.OnSetup();
        }

        public T Get<T>() where T : IService => TryGet<T>(out var service) ? service : default(T);

        public bool TryGet<T>(out T service) where T : IService
        {
            service = default;
            
            foreach (var serviceStorage in _serviceStorages.Values)
            {
                if (!serviceStorage.TryGet(out service)) continue;

                return true;
            }

            return false;
        }

        public void RegisterService<T>(IBootstrapper scope) where T : IService, new()
        {
            if (!_serviceStorages.ContainsKey(scope)) return;
            if (_serviceStorages[scope].Contains<T>()) return;
            
            _serviceStorages[scope].Add<T>();  
            
            Debug.Log($"Service {typeof(T).Name} Added to {scope.GetType().Name} scope");
        }

        public void UnRegisterService<T>() where T : IService
        {
            foreach (var serviceStorage in _serviceStorages.Values)
                serviceStorage.Remove<T>();
        }
    }
}