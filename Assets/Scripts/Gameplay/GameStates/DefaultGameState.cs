// file DefaultGameState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Scenes;
using twinkocat.Core.Utilities;
using twinkocat.Storages;

namespace twinkocat.Gameplay.GameStates
{
    public class DefaultGameState : GameState
    {
        public override async void Do()
        {
            if (!StorageGetter.TryGetSceneGroupFromStorage(SceneGroup.DefaultGame, out var sceneDataList))
            {
                DebugOnce.LogError("No have sceneData for Game scene");
                return;
            }

            await MultipleSceneLoader.LoadScenes(sceneDataList);
        }
    }
}