using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace twinkocat.Core.Editor
{
    public static class ApplicationScenesEditor
    {
        private const string ApplicationSceneAssetPath = "Assets/Configuration/ApplicationScene.asset";

        [MenuItem("twinkocat/application_scenes")]
        public static void CreateApplicationSceneAsset()
        {
            StorageCreatorHelper.TargetStorage<ApplicationScenes>(ApplicationSceneAssetPath);
        }
    }
    
    public partial class StorageCreatorHelper : ScriptableObject
    {
        public static void TargetStorage<T>(string assetPath) where T : ScriptableObject
        {
            var existingAsset = AssetDatabase.LoadAssetAtPath<T>(assetPath)
                                ?? CreateAsset<T>(assetPath);


            Selection.activeObject = existingAsset;
            EditorGUIUtility.PingObject(existingAsset);
        }

        private static T CreateAsset<T>(string assetPath) where T : ScriptableObject
        {
            if (IsPathCorrect(assetPath, out var outPath) && !Directory.Exists(outPath))
                Directory.CreateDirectory(outPath);

            var instance = CreateInstance<T>();

            AssetDatabase.CreateAsset(instance, assetPath);
            AssetDatabase.SaveAssets();

            Debug.Log($"Asset created at path: {assetPath}");

            return instance;
        }

        private static bool IsPathCorrect(string assetPath, out string outPath)
        {
            outPath = string.Empty;

            var directoryPath = Path.GetDirectoryName(assetPath);

            if (string.IsNullOrEmpty(directoryPath))    return false;

            if (!directoryPath.Contains("Assets"))      throw new ArgumentException("Path must contain [Assets] folder!");

            outPath = directoryPath;

            return true;
        }
    }
}