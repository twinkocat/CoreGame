using System.Collections.Generic;
using UnityEngine;

namespace twinkocat.Core.Utilities
{
    public static class DebugOnce
    {
        private static readonly HashSet<string> _logOnce = new();
        private static readonly HashSet<string> _logWarningOnce = new();
        
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
    }
}