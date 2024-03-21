// file ObjectPool.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;
using System.Collections.Generic;
using twinkocat.Core.Pool.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace twinkocat.Core.Pool
{
    public class ObjectPool<T> : IObjectPool<T> where T : Component
    {
        private readonly Transform _poolHolder;
        private readonly Transform _activeHolder;

        private readonly bool _isExpandable;
        private readonly bool _isObjectActiveByDefault;
        private int           _poolObjectCount;

        private readonly T _prefab;
        private Stack<T>   _objectStack;
        private List<T>    _activeObjects;

        public int          PoolCount => _poolObjectCount;

        /// <summary>
        /// Creating object pool instance.
        /// </summary>
        public ObjectPool(T prefab, bool isExpandable, bool isActiveByDefault,
            int poolObjectCount, Transform activeHolder = null, Transform poolHolder = null)
        {
            _prefab                  = prefab;
            _activeHolder            = activeHolder;
            _poolHolder              = poolHolder;
            _isExpandable            = isExpandable;
            _isObjectActiveByDefault = isActiveByDefault;

            FillPool(poolObjectCount);
        }

        /// <summary>
        /// Fill object pool.
        /// </summary>
        private void FillPool(int count)
        {
            _objectStack     = new Stack<T>(count);
            _activeObjects   = new List<T>();

            for (var i = 0; i < count; i++)
            {
                _objectStack.Push(CreateObject());
                
                if (_isObjectActiveByDefault) PopObject();
            }
        }

        /// <summary>
        /// Create object
        /// </summary>
        private T CreateObject()
        {
            var obj = Object.Instantiate(_prefab, _activeHolder);

            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_poolHolder);

            _poolObjectCount++;

            if (obj is ICreateInPool iPopFromPool)
                iPopFromPool.OnCreate();

            return obj;
        }

        public T PeekObject() => _objectStack.TryPeek(out var obj) ? obj : default; 

        /// <summary>
        /// Pop object from pool.
        /// </summary>
        public T PopObject(Transform parent = null)
        {
            if (_objectStack.TryPop(out var obj))
            { }
            else if (_isExpandable)
                obj = CreateObject();
            else
                throw new PoolIsNotExpandableException();

            obj.gameObject.SetActive(true);
            obj.transform.SetParent(parent ? parent : _activeHolder);
            
            _activeObjects.Add(obj);

            DynamicObjectInPoolUpdate();
            
            if (obj is IPopFromPool iPopFromPool)
                iPopFromPool.OnPop();
            
            return obj;
        }

        /// <summary>
        /// Return object to pool.
        /// </summary>
        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_poolHolder);

            _activeObjects.Remove(obj);
            _objectStack.Push(obj);

            if (obj is IReturnToPool iPopFromPool)
                iPopFromPool.OnReturn();
        }

        /// <summary>
        /// Return all active objects to pool
        /// </summary>
        public void ReleaseAllObjects()
        {
            foreach (var obj in _activeObjects)
                ReturnObject(obj);

            _activeObjects.Clear();
        }

        /// <summary>
        /// Destroy pool.
        /// </summary>
        public void DestroyPool()
        {
            for (var i = 0; i < _objectStack.Count; i++)
                Object.Destroy(_objectStack.Pop());

            _poolObjectCount = 0;
        }

        /// <summary>
        /// If object is dynamicObjectInPool, check it's useless iteration.
        /// If useless iteration is more than useless iteration limit, destroy object.
        /// </summary>
        private void DynamicObjectInPoolUpdate()
        {
            if (_objectStack.TryPeek(out var obj) && obj is IDynamicObjectInPool dynamicObj)
            {
                dynamicObj.NotUsedIteration++;

                if (dynamicObj.NotUsedIteration > dynamicObj.NotUsedIterationLimit)
                {
                    Object.Destroy(_objectStack.Pop().gameObject);
                    _poolObjectCount--;
                }
            }
        }
        private class PoolIsNotExpandableException : Exception { }
    }

}