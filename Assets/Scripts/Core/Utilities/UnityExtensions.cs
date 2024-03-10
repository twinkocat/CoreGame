using UnityEngine;

namespace twinkocat.Core.Utilities
{
    public static class UnityExtensions
    {
        public static T DontDestroyOnLoad<T>(this T obj) where T : Object
        {
            Object.DontDestroyOnLoad(obj);
            return obj;
        }

        public static T SpawnComponent<T>(string name) where T : Component => new GameObject(name, typeof(T)).GetComponent<T>();
        public static T SpawnComponent<T>() where T : Component => SpawnComponent<T>(typeof(T).Name);
        
        public static T LoadAndInstantiate<T>(string path, Vector3 position, Quaternion quaternion, Transform parent = null)
            where T : Object
        {
            var item = Resources.Load<T>(path);
            return Object.Instantiate(item, position, quaternion, parent);
        }

        public static T LoadAndInstantiate<T>(string path) where T : Object => LoadAndInstantiate<T>(path, Vector3.zero, Quaternion.identity);

        public static bool HaveComponent<T>(this GameObject gameObject) => gameObject.TryGetComponent<T>(out _);
        
        public static bool IsDestroyed(this Object target) => !ReferenceEquals(target, null) && target == null;
    }
}