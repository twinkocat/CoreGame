// file ApplicationScenes.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Eflatun.SceneReference;
using twinkocat.Core.Bootstrap;
using UnityEngine;

#endregion

namespace twinkocat.Core
{
    public class ApplicationScenes : ScriptableObject
    {
        [SerializedDictionary("SceneRef", "Bootstrapper Prefab")] [SerializeField] 
        private SerializedDictionary<SceneReference, Bootstrapper> _sceneData;
        
        public IDictionary<SceneReference, Bootstrapper> SceneData => _sceneData;
    }
}