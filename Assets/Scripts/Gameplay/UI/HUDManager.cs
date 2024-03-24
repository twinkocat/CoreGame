// file HUDManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;
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
        private IEnumerable<IHUDPresenter> _hudPresenters = UIHelper.InitViews(
            new List<IHUDPresenter>());

        public bool IsOpen(HUDType uiType)
        {
            throw new NotImplementedException();
        }

        public void Open(HUDType uiType)
        {
            throw new NotImplementedException();
        }

        public void Close(HUDType uiType)
        {
            throw new NotImplementedException();
        }
    }
}