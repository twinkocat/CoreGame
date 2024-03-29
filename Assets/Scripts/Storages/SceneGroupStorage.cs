﻿// file SceneGroupStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using twinkocat.Core.Scenes;
using twinkocat.Gameplay;
using UnityEngine;

namespace twinkocat.Storages
{
    public class SceneGroupStorage : ScriptableObject
    {
        [SerializedDictionary("GroupType", "Scene")]
        public SerializedDictionary<SceneGroup, List<SceneData>> sceneGroups;
    }
}