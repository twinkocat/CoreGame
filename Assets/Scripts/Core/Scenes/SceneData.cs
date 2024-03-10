using System;
using Eflatun.SceneReference;
using twinkocat.Core.Enums;

namespace twinkocat.Core.Scenes
{
    [Serializable]
    public class SceneData
    {
        public SceneReference reference;
        public SceneType      sceneType;
        public string         Name => reference.Name;
    }
}