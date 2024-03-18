// file UIBehaviour.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using twinkocat.Core.Utilities;
using twinkocat.Gameplay.UI.MainMenu;
using twinkocat.UI.Interfaces;
using twinkocat.UI.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace twinkocat.UI
{
    public class UIBehaviour : MonoBehaviour
    {
        [SerializeField] private UIStorage _uiStorage;

        private List<IPresenter> _presenters;
        
        private void Awake()
        {
            this.DontDestroyOnLoad();
            
            SceneManager.sceneLoaded   += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            
            RegisterPresenters();
            
            HUDManager    .Instance.Initialize(_presenters);
            WindowManager .Instance.Initialize(_presenters);
        }

        private void RegisterPresenters()
        {
            _presenters = new List<IPresenter>()
            {
                RegisterPresenter<MainMenuPresenter>(),
                
            };
        }
        
        private IPresenter RegisterPresenter<T>() where T : IPresenter, new()
        {
            var newPresenter = new T();
            var isSuccess = _uiStorage.Any(viewPrefab => newPresenter.TryInjectViewComponent(viewPrefab));
            
            if (!isSuccess) Debug.Log($"View for {typeof(T)} not found");
            
            return newPresenter;
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
        }
        
        private void OnSceneUnloaded(Scene scene)
        {
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded   -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
    }
}