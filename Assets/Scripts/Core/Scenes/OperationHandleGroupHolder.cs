// file OperationHandleGroupHolder.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Core.Scenes
{
    public static class OperationHandleGroupHolder
    {
        private static AsyncOperationHandleGroup _handleGroup;

        public static AsyncOperationHandleGroup CreateHandleGroup(int capacity)
        {
            return _handleGroup = new AsyncOperationHandleGroup(capacity);
        }

        public static AsyncOperationHandleGroup GetCurrentGroup()
        {
            return _handleGroup;
        }
    }
}