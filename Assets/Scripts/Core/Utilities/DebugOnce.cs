// file DebugOnce.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace twinkocat.Core.Utilities
{
    public static class DebugOnce
    {
        private static readonly HashSet<string> _logOnce = new();
        private static readonly HashSet<string> _logWarningOnce = new();
        private static readonly HashSet<string> _logErrorOnce = new();

        public static void Log(string message)
        {
            if (!_logOnce.Add(message)) return;

            Debug.Log(message);
        }

        public static void LogWarning(string message)
        {
            if (!_logWarningOnce.Add(message)) return;

            Debug.LogWarning(message);
        }

        public static void LogError(string message)
        {
            if (!_logErrorOnce.Add(message)) return;

            Debug.LogError(message);
        }
    }
}