﻿using UnityEngine;

namespace twinkocat.Core.Utilities
{
    [DisallowMultipleComponent]
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        private static T _instance;
        public static T Instance => _instance ??= RemoveAndKeepOneInstance() ?? UnityExtensions.SpawnComponent<T>();

        private static T RemoveAndKeepOneInstance()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var objectsOfType = FindObjectsOfType<T>();
#pragma warning restore CS0618 // Type or member is obsolete

            if (objectsOfType.IsNullOrEmpty())
                return null;

            for (var index = 1; index < objectsOfType.Length; index++)
                Destroy(objectsOfType[index]);

            return objectsOfType[0];
        }
    }
}