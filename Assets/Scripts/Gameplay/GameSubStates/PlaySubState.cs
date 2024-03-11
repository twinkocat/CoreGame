// file PlaySubState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Services;
using twinkocat.Gameplay.Global.Services;

namespace twinkocat.Gameplay.GameSubStates
{
    public class PlaySubState : IGameSubState
    {
        private readonly PauseService _pauseService = ServiceLocator.Interface.Get<PauseService>();

        public void DoSubState()
        {
            if (!_pauseService.IsPaused) return;

            _pauseService.SetPause(false);
        }
    }
}