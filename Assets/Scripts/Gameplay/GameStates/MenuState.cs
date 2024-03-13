// file MenuState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.


using System.Threading.Tasks;
using twinkocat.Core.Scenes;
using twinkocat.Core.Services;
using twinkocat.Gameplay.Global.Services;
using twinkocat.Storages;
using UnityEngine;

namespace twinkocat.Gameplay.GameStates
{
    public class MenuState : IGameState
    {
        public async void Do()
        {
            await DoStart();
            DoEnd();
        }

        private async Task DoStart()
        {
            if (!StorageGetter.TryGetSceneGroupFromStorage(SceneGroup.Menu, out var sceneDataList))
            {
                Debug.LogError("No have sceneData for Menu scene");
                return;
            }

            await MultipleSceneLoader.LoadScenes(sceneDataList);
            
            if (ServiceLocator.Interface.TryGet<MusicService>(out var musicService))
                musicService.PlayMusic(Music.MainMenuTheme, true);
        }

        private void DoEnd()
        {
            
        }


        public void Exit()
        {
        }
    }
}