// file UnityExtensions.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace twinkocat.Core.Utilities
{
    public static class UnityExtensions
    {
        public static T DontDestroyOnLoad<T>(this T obj) where T : Object
        {
            Object.DontDestroyOnLoad(obj);
            return obj;
        }

        public static T SpawnComponent<T>(string name) where T : Component
        {
            return new GameObject(name, typeof(T)).GetComponent<T>();
        }

        public static T SpawnComponent<T>() where T : Component
        {
            return SpawnComponent<T>(typeof(T).Name);
        }

        public static T LoadAndInstantiate<T>(string path, Vector3 position, Quaternion quaternion,
            Transform parent = null)
            where T : Object
        {
            var item = Resources.Load<T>(path);
            return Object.Instantiate(item, position, quaternion, parent);
        }

        public static T LoadAndInstantiate<T>(string path) where T : Object
        {
            return LoadAndInstantiate<T>(path, Vector3.zero, Quaternion.identity);
        }

        public static bool HaveComponent<T>(this GameObject gameObject)
        {
            return gameObject.TryGetComponent<T>(out _);
        }

        public static bool IsDestroyed(this Object target)
        {
            return !ReferenceEquals(target, null) && target == null;
        }

        public static Coroutine PlayWithPossibleNullEndCallback(this AudioSource audioSource, Action callback)
        {
            audioSource.Play();

            return callback != null && Coroutines.IsInitialized
                ? Coroutines.StartCoroutine(CallbackRoutine(audioSource.clip.length, callback))
                : null;
        }

        private static IEnumerator CallbackRoutine(float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback.SafeInvoke();
        }
    }
}