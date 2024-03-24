// file AsyncOperationGroup.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#endregion

namespace twinkocat.Core.Scenes
{
    public readonly struct AsyncOperationGroup
    {
        public bool IsDone => _operations.All(operation => operation.isDone);
        public float Progress => _operations.Average(operation => operation.progress);


        private readonly List<AsyncOperation> _operations;

        public AsyncOperationGroup(int capacity)
        {
            _operations = new List<AsyncOperation>(capacity);
        }

        public void Add(AsyncOperation asyncOperation)
        {
            _operations.Add(asyncOperation);
        }
    }
}