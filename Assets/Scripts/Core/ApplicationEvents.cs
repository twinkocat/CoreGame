// file ApplicationEvents.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System;
using twinkocat.Core.Bootstrap.Interfaces;

#endregion

namespace twinkocat.Core
{
    public static class ApplicationEvents
    {
        public static Action<float>          OnLoadingInProgress;
        public static Action<IBootstrapper>  OnBootstrapperLoad;
        public static Action                 OnApplicationLoad;
    }
}