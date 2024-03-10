// file SceneLoadManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using twinkocat.Core.Enums;
using twinkocat.Core.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace twinkocat.Core.Scenes
{
    public static class MultipleSceneLoader 
    {
        private static readonly LoadingScreen LoadingScreen = UnityExtensions.LoadAndInstantiate<LoadingScreen>("LoadingScreen");

        public static async Task LoadScenes(List<SceneData> scenesToLoadList, bool loadScreenActive = true, bool reloadDubScene = false)
        {
            var loadedScenes     = new List<string>();

            if (loadScreenActive) LoadingScreen.ShowLoading();
            
            await UnloadScenes(scenesToLoadList);

            for (var i = 0; i < SceneManager.sceneCount; i++)
                loadedScenes.Add(SceneManager.GetSceneAt(i).name);

            var operationGroup = new AsyncOperationGroup(scenesToLoadList.Count);

            foreach (var sceneData in scenesToLoadList)
            {
                if (!reloadDubScene && loadedScenes.Contains(sceneData.Name)) continue;
                
                operationGroup.Add(SceneManager.LoadSceneAsync(sceneData.reference.Path, LoadSceneMode.Additive));
                await Task.Delay(500);
            }

            while (!operationGroup.IsDone) await Task.Delay(100);

            var activeScene = SceneManager.GetSceneByName(scenesToLoadList.FirstOrDefault(sceneData => sceneData.sceneType is SceneType.ActiveScene)?.Name);

            if (activeScene.IsValid()) SceneManager.SetActiveScene(activeScene);
            if (loadScreenActive) LoadingScreen.HideLoading();
        }

        private static async Task UnloadScenes(List<SceneData> sceneToLoad)
        {
            var sceneToUnload = new List<string>();
            var sceneCount = SceneManager.sceneCount;
            
            for (var i = sceneCount - 1; i > 0; i--)
            {
                var sceneAt = SceneManager.GetSceneAt(i);
                
                if (!sceneAt.isLoaded) continue;
                if (sceneAt.name.Equals("Bootstrap")) continue;
                if (sceneToLoad.Exists(scene => scene.Name.Equals(sceneAt.name))) continue;
                
                sceneToUnload.Add(sceneAt.name);
            }

            var operationGroup = new AsyncOperationGroup(sceneToUnload.Count);

            foreach (var scene in sceneToUnload)
                operationGroup.Add(SceneManager.UnloadSceneAsync(scene));

            while (!operationGroup.IsDone) await Task.Delay(100);

            await Resources.UnloadUnusedAssets();
        }
    }
}