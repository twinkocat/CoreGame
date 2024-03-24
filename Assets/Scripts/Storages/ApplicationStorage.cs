// file ApplicationStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using twinkocat.Core.Scenes;
using twinkocat.Core.Utilities;
using UnityEngine;

namespace twinkocat.Storages
{
    public class ApplicationStorage : SingletonBehaviour<ApplicationStorage>
    {
        [SerializeField] private SceneGroupStorage _sceneGroupStorage;
        [SerializeField] private MusicStorage      _musicStorage;
        [SerializeField] private UIStorage         _uiStorage;
        
        public SceneGroupStorage SceneGroupStorage => _sceneGroupStorage;
        public MusicStorage      MusicStorage      => _musicStorage;
        public UIStorage         UIStorage         => _uiStorage;
        
        private void Awake() => this.DontDestroyOnLoad();
    }

    public static class StorageGetter
    {
        public static bool TryGetMusicClipFromStorage(Music music, out AudioClip clip)
            => ApplicationStorage.Instance.MusicStorage.musicData.TryGetValue(music, out clip);

        public static bool TryGetSceneGroupFromStorage(SceneGroup group, out List<SceneData> sceneData)
            => ApplicationStorage.Instance.SceneGroupStorage.sceneGroups.TryGetValue(group, out sceneData);

        public static UIStorage GetUIStorage() 
            => ApplicationStorage.Instance.UIStorage;
    }
}