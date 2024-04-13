using System;
using twinkocat.UI.Entities;
using UnityEngine;

namespace twinkocat.UI.Interfaces
{
    public interface IPresenter : IDisposable
    {
        public bool TryInjectViewComponent(View viewPrefab);

        public void Open(Transform anchor = null);
        public void Close();
    }
}