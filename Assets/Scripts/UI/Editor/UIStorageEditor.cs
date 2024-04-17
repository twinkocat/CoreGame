// file UIStorageEditor.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Editor;
using twinkocat.UI.Storage;
using UnityEditor;

namespace twinkocat.UI.Editor
{
    public static class UIStorageEditor
    {
        private const string ApplicationSceneAssetPath = "Assets/Configuration/UIStorage.asset";

        [MenuItem("twinkocat/ui_storage")]
        public static void CreateApplicationSceneAsset()
        {
            StorageCreatorHelper.TargetStorage<UIStorage>(ApplicationSceneAssetPath);
        }
    }
}