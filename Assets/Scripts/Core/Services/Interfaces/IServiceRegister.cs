// file IServiceRegister.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using twinkocat.Core.Bootstrap.Interfaces;
using UnityEngine;

#endregion

namespace twinkocat.Core.Services.Interfaces
{
    public interface IServiceRegister
    {
        void RegisterService<T>(IBootstrapper scope) where T : IService, new();
        void RegisterServiceBehaviour<T>(IBootstrapper scope) where T : MonoBehaviour, IService, new();
        void UnRegisterService<T>() where T : IService;
    }
}