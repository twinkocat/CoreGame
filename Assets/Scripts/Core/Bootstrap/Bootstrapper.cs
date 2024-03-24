// file Bootstrapper.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using twinkocat.Core.Bootstrap.Interfaces;
using twinkocat.Core.Services.Interfaces;
using UnityEngine;

#endregion

namespace twinkocat.Core.Bootstrap
{
    public abstract class Bootstrapper : MonoBehaviour, IBootstrapper
    {
        public abstract void RegisterServices(IServiceRegister serviceRegister);
    }
}