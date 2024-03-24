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
        Settings
    }

    public class WindowManager : LazySingleton<WindowManager>, IUIManager<IWindowPresenter, WindowType>
    {
        private readonly List<IWindowPresenter> _activePresenters = new();

        private readonly IEnumerable<IWindowPresenter> _windowPresenters = UIHelper.InitViews(
            new List<IWindowPresenter>
            {
                new SettingsWindow()
            });

        private readonly Stack<IWindowPresenter> _windowStack = new();

        public bool IsOpen(WindowType uiType)
        {
            return _activePresenters.Any(window => window.WindowType == uiType);
        }

        public void Open(WindowType uiType)
        {
            var window = _windowPresenters.FirstOrDefault(window => window.WindowType == uiType);

            if (window == null) return;

            window.OpenWindow();

            _windowStack.Push(window);
            _activePresenters.Add(window);
        }


        public void Close(WindowType uiType)
        {
            if (!_activePresenters.TryFind(window => window.WindowType == uiType, out _)) return;
        }
    }
}