using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace twinkocat.Core.Scenes
{
    public readonly struct AsyncOperationGroup
    {
        public bool IsDone   => _operations.All(operation => operation.isDone);
        
        private readonly List<AsyncOperation> _operations;

        public AsyncOperationGroup(int capacity) => _operations = new List<AsyncOperation>(capacity);

        public void Add(AsyncOperation asyncOperation) => _operations.Add(asyncOperation);
    }
}