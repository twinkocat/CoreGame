// file SceneData.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System;
using Eflatun.SceneReference;

#endregion

namespace twinkocat.Core.Scenes
{
    [Serializable]
    public class SceneData
    {
        public SceneReference reference;
        public SceneType sceneType;
        public string Name => reference.Name;
    }
}