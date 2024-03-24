// file BootstrapperStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Eflatun.SceneReference;
using twinkocat.Core.Bootstrap;
using UnityEngine;

#endregion

namespace twinkocat.Core.Scenes
{
    public class BootstrapperStorage : ScriptableObject
    {
        [SerializedDictionary("SceneRef", "Bootstrapper Prefab")] [SerializeField]
        private SerializedDictionary<SceneReference, Bootstrapper> scenes;

        public IDictionary<SceneReference, Bootstrapper> Scenes => scenes;
    }
}