// file WindowManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using twinkocat.Core.Utilities;
using twinkocat.Gameplay.UI.Settings;
using twinkocat.UI.Interfaces;

namespace twinkocat.Gameplay.UI
{
    public enum WindowType
    {
        Settings,
    }
    
    public class WindowManager : LazySingleton<WindowManager>, IUIManager<IWindowPresenter, WindowType>
    {
        private readonly List<IWindowPresenter>  _windowPresenters = new()
        {
            new SettingsPresenter(),
        };
        
        private readonly List<IWindowPresenter>  _activePresenters = new();
        private readonly Stack<IWindowPresenter> _windowStack      = new();
        
        private bool _isInitialized;
        
        public bool IsOpen(WindowType uiType) => _activePresenters.Any(x => x.WindowType == uiType);

        public void Open(WindowType uiType)
        {
            var window = _windowPresenters.FirstOrDefault(x => x.WindowType == uiType);
            
            if (window == null) return;

            window.OpenWindow();
            _windowStack.Push(window);
            _activePresenters.Add(window);
        }

        public void Close(WindowType uiType)
        {
            if (!_activePresenters.TryFind(x => x.WindowType == uiType, out var activeWindow)) return;
            
        }
    }
}