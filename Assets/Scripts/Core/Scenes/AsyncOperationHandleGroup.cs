// file AsyncOperationHandleGroup.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace twinkocat.Core.Scenes
{
    public readonly struct AsyncOperationHandleGroup : IEnumerable<AsyncOperationHandle<SceneInstance>>
    {
        private readonly List<AsyncOperationHandle<SceneInstance>> _handles;

        public float Progress => _handles.Count == 0 ? 0 : _handles.Average(operation => operation.PercentComplete);
        public bool IsDone => _handles.Count == 0 || _handles.All(operation => operation.IsDone);

        public AsyncOperationHandleGroup(int capacity)
        {
            _handles = new List<AsyncOperationHandle<SceneInstance>>(capacity);
        }

        public void Add(AsyncOperationHandle<SceneInstance> operationHandle)
        {
            _handles.Add(operationHandle);
        }

        public void SafeClear()
        {
            _handles?.Clear();
        }

        public IEnumerator<AsyncOperationHandle<SceneInstance>> GetEnumerator()
        {
            return _handles?.GetEnumerator() ?? Enumerable.Empty<AsyncOperationHandle<SceneInstance>>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}