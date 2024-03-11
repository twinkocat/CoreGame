// file PauseService.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using twinkocat.Core.Services.Interfaces;

namespace twinkocat.Gameplay.Global.Services
{
    public interface IPauseHandler
    {
        void SetPause(bool isPaused);
    }
    
    public class PauseService : IService, IPauseHandler
    {
        public bool     IsPaused { get; private set; }
        
        private readonly HashSet<IPauseHandler> _pauseHandlers = new();
        
        public void OnSetup() { }

        public void SetPause(bool isPaused)
        {
            IsPaused = isPaused;

            foreach (var pauseHandler in _pauseHandlers)
                pauseHandler.SetPause(isPaused);
        }
        
        public void Register  (IPauseHandler pauseHandler) => _pauseHandlers.Add(pauseHandler);
        public void UnRegister(IPauseHandler pauseHandler) => _pauseHandlers.Remove(pauseHandler);

        public void Dispose() => _pauseHandlers.Clear();
    }
}