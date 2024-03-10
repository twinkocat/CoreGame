using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using twinkocat.Core.Bootstrap;
using UnityEngine;

namespace twinkocat.Core
{
    public class ApplicationScenes : ScriptableObject
    {
        [SerializedDictionary("SceneRef", "Bootstrapper Prefab")] [SerializeField] 
        private SerializedDictionary<SceneReference, Bootstrapper> _sceneData;
        
        public IDictionary<SceneReference, Bootstrapper> SceneData => _sceneData;
    }
}