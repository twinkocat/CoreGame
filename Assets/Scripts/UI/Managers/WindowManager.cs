// file WindowManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using twinkocat.Core.Utilities;
using twinkocat.UI.Interfaces;

namespace twinkocat.UI.Managers
{
    public enum WindowType
    {
        Settings,
    }
    
    public class WindowManager : LazySingleton<WindowManager>, IUIManager<IWindowPresenter, WindowType>
    {
        private readonly List<IWindowPresenter> _windowPresenters = new();
        private readonly List<IWindowPresenter> _activePresenters = new();
        
        private bool _isInitialized;

        public void Initialize(List<IPresenter> presenters)
        {
            if (_isInitialized || presenters.IsNullOrEmpty()) return;
            
            foreach (var presenter in presenters)
            {
                if (presenter is not IWindowPresenter windowPresenter) continue;
                
                _windowPresenters.Add(windowPresenter);
            }

            _isInitialized = true;
        }

        public void Open(WindowType uiType)
        {
            throw new System.NotImplementedException();
        }

        public void Close(WindowType uiType)
        {
            throw new System.NotImplementedException();
        }
    }
}