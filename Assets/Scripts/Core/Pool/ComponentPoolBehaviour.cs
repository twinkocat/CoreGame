// file ComponentPoolBehaviour.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Pool.Interfaces;
using UnityEngine;

namespace twinkocat.Core.Pool
{
    public class ComponentPoolBehaviour : MonoBehaviour
    {
        private IObjectPool<Component>     _objectPool;
        
        [SerializeField] private Component prefab;
        [SerializeField] private int       objectCount;
        [SerializeField] private bool      isExpandable;
        [SerializeField] private bool      isActiveByDefault;
        [SerializeField] private Transform poolHolder;
        [SerializeField] private Transform activeHolder;
        
        private void Awake() => _objectPool = new ObjectPool<Component>(prefab, isExpandable, isActiveByDefault, objectCount, activeHolder, poolHolder);

        public bool TryPopComponent<T>(out T popComponent, Transform parent = null) where T : Component
        {
            popComponent = default;

            var peekComponent = _objectPool.PeekObject();

            if (!isExpandable && peekComponent == null) return false;
            if (!isExpandable && !peekComponent.TryGetComponent<T>(out _)) return false;
            
            
            popComponent = _objectPool.PopObject(parent).GetComponent<T>();

            return true;
        }

        public void ReturnComponent<T>(T returnComponent) where T : Component 
            => _objectPool.ReturnObject(returnComponent);
        
        public void ReleaseAllComponents() => _objectPool.ReleaseAllObjects();
        public void DestroyComponentPool() => _objectPool.DestroyPool();

    }
}