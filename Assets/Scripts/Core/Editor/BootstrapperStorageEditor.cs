// file BootstrapperStorageEditor.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using twinkocat.Core.Scenes;
using UnityEditor;

#endregion

namespace twinkocat.Core.Editor
{
    public static class BootstrapperStorageEditor
    {
        private const string ApplicationSceneAssetPath = "Assets/Configuration/BootstrapperStorage.asset";

        [MenuItem("twinkocat/bootstrapper_storage")]
        public static void CreateApplicationSceneAsset()
        {
            StorageCreatorHelper.TargetStorage<BootstrapperStorage>(ApplicationSceneAssetPath);
        }
    }
}