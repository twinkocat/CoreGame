// file HUDManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using twinkocat.Core.Utilities;
using twinkocat.UI.Interfaces;

namespace twinkocat.Gameplay.UI
{
    public enum HUDType
    {
        
    }
    
    public class HUDManager : LazySingleton<HUDManager>, IUIManager<IHUDPresenter, HUDType>
    {
        private List<IHUDPresenter> _hudPresenters = new();
        private bool _isInitialized;

        public bool IsOpen(HUDType uiType) => throw new System.NotImplementedException();
        
        public void Initialize(List<IPresenter> presenters)
        {
            if (_isInitialized || presenters.IsNullOrEmpty()) return;
            
            foreach (var presenter in presenters)
            {
                if (presenter is not IHUDPresenter windowPresenter) continue;
                
                _hudPresenters.Add(windowPresenter);
            }

            _isInitialized = true;
        }

        public void Open(HUDType uiType)
        {
            throw new System.NotImplementedException();
        }

        public void Close(HUDType uiType)
        {
            throw new System.NotImplementedException();
        }
    }
}