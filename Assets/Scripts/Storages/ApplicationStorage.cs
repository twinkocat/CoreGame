// file ApplicationStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Utilities;
using twinkocat.Storages;
using UnityEngine;

namespace twinkocat.Gameplay
{
    public class ApplicationStorage : SingletonBehaviour<ApplicationStorage>
    {
        [SerializeField] private SceneGroupStorage _sceneGroupStorage;
        
        
        public SceneGroupStorage SceneGroupStorage => _sceneGroupStorage;
    }
}