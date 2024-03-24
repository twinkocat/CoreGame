// file StorageCreatorHelper.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Editor;
using twinkocat.Gameplay;
using UnityEditor;
using UnityEngine;

namespace twinkocat.Storages.Editor
{
    public class StorageCreator : ScriptableObject
    {
        [MenuItem("twinkocat/storage/scene_group_storage")]
        public static void SceneGroupStorage()
        {
            StorageCreatorHelper.TargetStorage<SceneGroupStorage>(ConstPath.SceneGroupStoragePath);
        }

        [MenuItem("twinkocat/storage/music_storage")]
        public static void MusicStorage()
        {
            StorageCreatorHelper.TargetStorage<MusicStorage>(ConstPath.MusicStoragePath);
        }
    }
}