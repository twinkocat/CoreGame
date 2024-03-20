// file IObjectPool.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using UnityEngine;

namespace twinkocat.Core.Pool.Interfaces
{
    public interface IObjectPool<T> where T : Component
    {
        int PoolCount { get; }
        T PopObject(Transform parent = null);
        void ReturnObject(T obj);
        void ReleaseAllObjects();
        void DestroyPool();
    }
}