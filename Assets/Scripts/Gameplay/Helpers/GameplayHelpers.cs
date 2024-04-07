// file GameplayHelpers.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Gameplay.Helpers
{
    public static class GameplayHelpers
    {
        public static GameInstance GameInstance(this object @object) => Gameplay.GameInstance.Instance;
    }
}