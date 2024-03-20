// file ObjectPoolBehaviour.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Pool.Interfaces;
using UnityEngine;

namespace twinkocat.Core.Pool
{
    
    public class ObjectPoolBehaviour : MonoBehaviour
    {
        public IObjectPool<Component>      ObjectPool { get; private set; }
        
        [SerializeField] private Component component;
        [SerializeField] private int       objectCount;
        [SerializeField] private bool      isExpandable;
        [SerializeField] private bool      isActiveByDefault;
        [SerializeField] private Transform poolHolder;
        [SerializeField] private Transform activeHolder;
        
        private void Awake() => ObjectPool = new ObjectPool<Component>(component, isExpandable, isActiveByDefault, objectCount, activeHolder, poolHolder);
    }
}