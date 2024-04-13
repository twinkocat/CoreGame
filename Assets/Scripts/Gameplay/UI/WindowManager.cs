// file WindowManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using twinkocat.Core.Utilities;
using twinkocat.Gameplay.UI.Helpers;
using twinkocat.Gameplay.UI.Settings;
using twinkocat.UI.Interfaces;
using UnityEngine;

namespace twinkocat.Gameplay.UI
{
    public enum WindowType
    {
        Settings
    }

    public class WindowManager : SingletonBehaviour<WindowManager>, IUIManager<IWindowPresenter, WindowType>
    {
        [SerializeField] private Transform _windowAnchor;
        
        private List<IWindowPresenter> _activePresenters;
        private Stack<IWindowPresenter> _windowStack;

        private IEnumerable<IWindowPresenter> _windowPresenters;
    
        
        private void Start()
        {
            Debug.Log("Start");
            
            _activePresenters = new List<IWindowPresenter>();
            _windowStack      = new Stack<IWindowPresenter>();
            _windowPresenters = UIHelper.InitViews(new List<IWindowPresenter>
            {
                new SettingsWindow(),
                
            });
        }

        public bool IsOpen(WindowType uiType)
        {
            return _activePresenters.Any(window => window.WindowType == uiType);
        }

        public void Open(WindowType uiType)
        {
            var window = _windowPresenters.FirstOrDefault(window => window.WindowType == uiType);

            if (window == null) return;
            
            window.Open(_windowAnchor);

            _windowStack.Push(window);
            _activePresenters.Add(window);
        }


        public void Close(WindowType uiType)
        {
            if (!_activePresenters.TryFind(window => window.WindowType == uiType, out _)) return;
        }

        private void OnDisable()
        {
            if (_windowPresenters == null) return;
            
            foreach (var windowPresenter in _windowPresenters)
                windowPresenter.Dispose();
        }
    }
}