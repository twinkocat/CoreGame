using twinkocat.UI.Interfaces;
using UnityEngine;

namespace twinkocat.UI.Entities
{
    public abstract class Presenter<TView> : IPresenter where TView : View
    {
        private   TView _viewPrefab;
        protected TView View;

        public bool TryInjectViewComponent(View viewPrefab)
        {
            if (viewPrefab is not TView tViewPrefab) return false;

            _viewPrefab = tViewPrefab;
            return true;
        }
        
        public void SpawnView() => View = Object.Instantiate(_viewPrefab);
    }
}