using twinkocat.Core.Bootstrap.Interfaces;
using twinkocat.Core.Services.Interfaces;
using UnityEngine;

namespace twinkocat.Core.Bootstrap
{
    public abstract class Bootstrapper : MonoBehaviour, IBootstrapper
    {
        public abstract void RegisterServices(IServiceRegister serviceRegister);

    }
}