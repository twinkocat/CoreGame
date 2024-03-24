#region file

// file: Coroutines.cs created by author: twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#endregion

using System;
using System.Collections;
using UnityEngine;

namespace twinkocat.Core.Utilities
{
    public static class Coroutines
    {
        private static MonoBehaviour _coroutineRunner;

        public static bool IsInitialized => _coroutineRunner is not null;


        public static void Initialize(MonoBehaviour runner)
        {
            _coroutineRunner = runner;
        }

        public static Coroutine StartCoroutine(IEnumerator coroutine)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("CoroutineRunner in not initialized");

            return _coroutineRunner.StartCoroutine(coroutine);
        }

        public static void StopCoroutine(Coroutine coroutine)
        {
            if (!IsInitialized) return;

            _coroutineRunner.StopCoroutine(coroutine);
        }

        public static void StopCoroutine(ref Coroutine coroutine)
        {
            if (coroutine is null) return;

            StopCoroutine(coroutine);
        }
    }
}