// file LazySingleton.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Core.Utilities
{
    public abstract class LazySingleton<TClass> where TClass : class, new()
    {
        private static readonly object  _lock = new();
        private static TClass           _lazyInstance;

        public static TClass Instance
        {
            get
            {
                if (_lazyInstance != null) return _lazyInstance;

                lock (_lock)
                {
                    _lazyInstance ??= new TClass();
                }
                return _lazyInstance;
            }
        }
    }
    
    public abstract class LazySingleton<TClass, TInterface> where TClass : class, TInterface, new()
    {
        private static readonly object  _lock = new();
        private static TInterface       _lazyInstance;
        
        public static TInterface Interface
        {
            get
            {
                if (_lazyInstance != null) return _lazyInstance;
                
                lock (_lock)
                {
                    _lazyInstance ??= new TClass();
                }
                return _lazyInstance;
            }
        }

        public static TClass    GetInstance() => Interface as TClass;
        
    }
}