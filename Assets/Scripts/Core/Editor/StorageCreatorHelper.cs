﻿using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace twinkocat.Core.Editor
{
    public class StorageCreatorHelper : ScriptableObject
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

            if (string.IsNullOrEmpty(directoryPath)) return false;

            if (!directoryPath.Contains("Assets")) throw new ArgumentException("Path must contain [Assets] folder!");

            outPath = directoryPath;

            return true;
        }
    }
}