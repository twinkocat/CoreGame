// file UIBehaviour.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace twinkocat.UI
{
    public class UIBehaviour : MonoBehaviour
    {
        [SerializeField] private UIStorage _uiStorage;
        
        private void Awake()
        {
            this.DontDestroyOnLoad();
            
            SceneManager.sceneLoaded   += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
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