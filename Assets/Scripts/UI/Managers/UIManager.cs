// file UIManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using twinkocat.Core.Utilities;
using twinkocat.UI.Interfaces;

namespace twinkocat.UI.Managers
{
    public enum UIType
    {
        MainMenu,
    }
    
    public class UIManager : IUIManager<IUIPresenter, UIType>
    {
        private List<IUIPresenter> _hudPresenters = new();
        
        private bool _isInitialized;
        
        public void Initialize(List<IPresenter> presenters)
        {
            if (_isInitialized || presenters.IsNullOrEmpty()) return;
            
            foreach (var presenter in presenters)
            {
                if (presenter is not IUIPresenter windowPresenter) continue;
                
                _hudPresenters.Add(windowPresenter);
            }

            _isInitialized = true;
        }

        public void Open(UIType uiType)
        {
            throw new System.NotImplementedException();
        }

        public void Close(UIType uiType)
        {
            throw new System.NotImplementedException();
        }
    }
}