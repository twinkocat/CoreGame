using System;
using twinkocat.Core.Bootstrap.Interfaces;
using twinkocat.Core.Services.Interfaces;
using twinkocat.Core.Utilities;
using UnityEngine;

namespace twinkocat.Core.Bootstrap
{
    public abstract class Bootstrapper : MonoBehaviour, IBootstrapper
    {
        public Action<IBootstrapper> Unloaded { get; set; }

        public abstract void RegisterServices(IServiceRegister serviceRegister);

        private void OnDisable() => Unloaded.SafeInvoke(this);
    }
}