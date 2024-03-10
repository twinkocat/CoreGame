using System;
using twinkocat.Core.Bootstrap.Interfaces;

namespace twinkocat.Core
{
    public static class ApplicationEvents
    {
        public static Action<IBootstrapper>  OnBootstrapperLoad;
        public static Action                 OnApplicationLoad;
    }
}