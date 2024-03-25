// file ISceneLoader.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Threading.Tasks;
using twinkocat.Core.Scenes;
using twinkocat.Gameplay;

#endregion

namespace twinkocat.Core.Interfaces
{
    public interface ISceneLoader
    {
        Task LoadScenes(SceneGroup groupType, bool loadScreenActive = true, bool reloadDubScene = false);
        Task UnloadScenes();
    }
}