// file ExitState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Scenes;
using twinkocat.Core.Utilities;
using twinkocat.Storages;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace twinkocat.Gameplay.GameStates
{
    public class ExitState : IGameState
    {
        public async void Do()
        {
            if (!StorageGetter.TryGetSceneGroupFromStorage(SceneGroup.Exit, out var sceneDataList))
            {
                DebugOnce.LogError("No have sceneData for Game scene");
                return;
            }

            await MultipleSceneLoader.LoadScenes(sceneDataList);
            await SceneManager.UnloadSceneAsync("Bootstrap");
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif    
        }

        public void Exit()
        {
        }
    }
}