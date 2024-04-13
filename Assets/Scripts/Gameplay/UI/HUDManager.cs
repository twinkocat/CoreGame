// file HUDManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;
using System.Collections.Generic;
using twinkocat.Core.Utilities;
using twinkocat.Gameplay.UI.Helpers;
using twinkocat.UI.Interfaces;
using UnityEngine;

namespace twinkocat.Gameplay.UI
{
    public enum HUDType
    {
    }

    public class HUDManager : SingletonBehaviour<HUDManager>, IUIManager<IHUDPresenter, HUDType>
    {
        [SerializeField] private Transform _viewAnchor;
        
        private IEnumerable<IHUDPresenter> _hudPresenters;

        private void Start()
        {
            _hudPresenters = UIHelper.InitViews(new List<IHUDPresenter>
            {
            });
        }

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

        private void OnDisable()
        {
            if (_hudPresenters == null) return;

            foreach (var hudPresenter in _hudPresenters)
                hudPresenter.Dispose();
        }
    }
}