// file MusicStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace twinkocat.Storages
{
    public enum Music
    {
        MainMenuTheme,
    }
    
    public class MusicStorage : ScriptableObject
    {
        [SerializedDictionary("Music", "Clip")]
        public SerializedDictionary<Music, AudioClip> musicData;
    }
}