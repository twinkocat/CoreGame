// file GameState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Scenes;
using twinkocat.Core.Utilities;
using twinkocat.Storages;

namespace twinkocat.Gameplay.GameStates
{
    public class GameState : IGameState
    {
        public async void Do()
        {
            if (!StorageGetter.TryGetSceneGroupFromStorage(SceneGroup.Game, out var sceneDataList))
            {
                DebugOnce.LogError("No have sceneData for Game scene");
                return;
            }

            await MultipleSceneLoader.LoadScenes(sceneDataList);
        }
        public void Exit() { }
    }
}