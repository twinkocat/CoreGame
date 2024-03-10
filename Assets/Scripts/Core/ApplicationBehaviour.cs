// file ApplicationBehaviour.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System;
using System.Collections.Generic;
using twinkocat.Core.Bootstrap;
using twinkocat.Core.Bootstrap.Interfaces;
using twinkocat.Core.Scenes;
using twinkocat.Core.Services;
using twinkocat.Core.Utilities;
using twinkocat.Storages;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace twinkocat.Core
{
    public class ApplicationBehaviour : MonoBehaviour
    {
        [SerializeField] private bool _debugMode;
        [SerializeField] private bool _logEnabled;
        [SerializeField] private BootstrapperStorage _bootstrapperStorage;

        [SerializeField] private SceneGroupStorage _sceneGroupStorage;
        
        private readonly ServiceLocator _serviceLocator = ServiceLocator.GetInstance();
        private readonly Dictionary<Scene, IBootstrapper> _activeBootstrapper = new();

        private void Awake()
        {
            this.DontDestroyOnLoad();
            Defines.IsDebugMode             = _debugMode;
            Debug.unityLogger.logEnabled    = _logEnabled;
        }

        private void Start()
        {
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
            
            ApplicationEvents.OnApplicationLoad.SafeInvoke();
            
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (!TryFindPrefabInStorage(out var prefab, scene)) return;
            if (_activeBootstrapper.ContainsKey(scene)) return;
            
            IBootstrapper bootstrapper = Instantiate(prefab as Bootstrapper).DontDestroyOnLoad();
            
            _serviceLocator.CreateStorage(bootstrapper);
            _serviceLocator.Setup(bootstrapper);
            
            _activeBootstrapper.Add(scene, bootstrapper);
            
            Debug.Log($"{bootstrapper} loaded");
            ApplicationEvents.OnBootstrapperLoad.SafeInvoke(bootstrapper);
        }

        private void OnSceneUnloaded(Scene scene)
        {
            if (!_activeBootstrapper.TryGetValue(scene, out var bootstrapper)) return;
            
            _serviceLocator.DeleteStorage(bootstrapper);
            _activeBootstrapper.Remove(scene);
            Destroy(((MonoBehaviour)bootstrapper).gameObject);
            
            Debug.Log($"{bootstrapper} unloaded");
        }

        private bool TryFindPrefabInStorage(out IBootstrapper prefab, Scene scene)
        {
            var bootstrapperDictionary = _bootstrapperStorage.Scenes;

            if (bootstrapperDictionary.IsNull()) throw new NullReferenceException();

            prefab = null;
            
            foreach (var (sceneReference, bootstrapper) in bootstrapperDictionary)
            {
                if (sceneReference.BuildIndex != scene.buildIndex) continue;
                
                prefab = bootstrapper;
                return true;
            }
            
            DebugOnce.LogWarning($"Bootstrapper for {scene.name} not found. Add bootstrapper to bootstrapperStorage if needed");
            return false;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
    }
}
