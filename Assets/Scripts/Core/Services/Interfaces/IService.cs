// file IService.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System;

#endregion

namespace twinkocat.Core.Services.Interfaces
{
    public interface IService : IDisposable
    {
        void OnSetup();
    }
}