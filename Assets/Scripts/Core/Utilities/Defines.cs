namespace twinkocat.Core.Utilities
{
    public static class Defines
    {
        public static bool IsDebugMode;

#if UNITY_EDITOR
        public static readonly bool IsEditor = true;
#else
        public static readonly bool IsEditor = false;
#endif
        
    }
}