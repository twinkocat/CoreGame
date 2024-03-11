// file SceneLoadManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eflatun.SceneReference;
using twinkocat.Core.Enums;
using twinkocat.Core.Utilities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

#endregion

namespace twinkocat.Core.Scenes
{
    public static class MultipleSceneLoader
    {
        private static readonly LoadingScreen LoadingScreen = UnityExtensions.LoadAndInstantiate<LoadingScreen>("LoadingScreen") 
                                                              ?? throw new NullReferenceException("Need to create a LoadingScreenPrefab in ResourceFolder");

        public static async Task LoadSceneWithTryCatchBlock(List<SceneData> scenesToLoadList, bool loadScreenActive = true, bool reloadDubScene = false)
        {
            try
            {
                await LoadScenes(scenesToLoadList, loadScreenActive, reloadDubScene);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        
        public static async Task LoadScenes(List<SceneData> scenesToLoadList, bool loadScreenActive = true, bool reloadDubScene = false)
        {
            var loadedScenes     = new List<string>();

            if (loadScreenActive) LoadingScreen.ShowLoading();
            
            await UnloadScenes(scenesToLoadList);

            for (var i = 0; i < SceneManager.sceneCount; i++)
                loadedScenes.Add(SceneManager.GetSceneAt(i).name);

            var operationGroup  = new AsyncOperationGroup(scenesToLoadList.Count);
            var handleGroup     = OperationHandleGroupHolder.CreateHandleGroup(10);

            foreach (var sceneData in scenesToLoadList)
            {
                if (!reloadDubScene && loadedScenes.Contains(sceneData.Name)) continue;
                
                if (sceneData.reference.State is SceneReferenceState.Regular)
                {
                    operationGroup.Add(SceneManager.LoadSceneAsync(sceneData.reference.Path, LoadSceneMode.Additive));
                }
                else if (sceneData.reference.State is SceneReferenceState.Addressable)
                {
                    handleGroup.Add(Addressables.LoadSceneAsync(sceneData.reference.Path, LoadSceneMode.Additive));
                }
                
                await Task.Delay(500);
            }

            while (!operationGroup.IsDone || !handleGroup.IsDone)
            {
                ApplicationEvents.OnLoadingInProgress.SafeInvoke((operationGroup.Progress + handleGroup.Progress) / 2);
                await Task.Delay(100);
            }

            var activeScene = SceneManager.GetSceneByName(scenesToLoadList.FirstOrDefault(sceneData => sceneData.sceneType is SceneType.ActiveScene)?.Name);

            if (activeScene.IsValid()) SceneManager.SetActiveScene(activeScene);
            if (loadScreenActive) LoadingScreen.HideLoading();
        }

        private static async Task UnloadScenes(List<SceneData> sceneToLoad)
        {
            var sceneToUnload = new List<string>();
            var sceneCount = SceneManager.sceneCount;
            var handleGroup = OperationHandleGroupHolder.GetCurrentGroup();
            
            for (var i = sceneCount - 1; i > 0; i--)
            {
                var sceneAt = SceneManager.GetSceneAt(i);
                
                if (!sceneAt.isLoaded) continue;
                if (sceneAt.name.Equals("Bootstrap")) continue;
                if (sceneToLoad.Exists(scene => scene.Name.Equals(sceneAt.name))) continue;
                if (handleGroup.Any(operationHandle => operationHandle.IsValid() && operationHandle.Result.Scene.name == sceneAt.name)) continue;
                
                sceneToUnload.Add(sceneAt.name);
            }
            
            foreach (var handle in handleGroup)
            {
                if (!handle.IsValid()) continue;

                Addressables.UnloadSceneAsync(handle);
            }
            handleGroup.SafeClear();
            
            var operationGroup = new AsyncOperationGroup(sceneToUnload.Count);

            foreach (var scene in sceneToUnload)
                operationGroup.Add(SceneManager.UnloadSceneAsync(scene));

            while (!operationGroup.IsDone) await Task.Delay(100);

            await Resources.UnloadUnusedAssets();
        }
    }
}