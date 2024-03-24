using twinkocat.UI.Interfaces;
using UnityEngine;

namespace twinkocat.UI.Entities
{
    public abstract class Presenter<TView> : IPresenter where TView : View
    {
        private TView _viewPrefab;
        protected TView View;

        public bool TryInjectViewComponent(View viewPrefab)
        {
            if (_viewPrefab is not null || viewPrefab is not TView tViewPrefab) return false;

            _viewPrefab = tViewPrefab;
            return true;
        }

        public void SpawnView()
        {
            View = Object.Instantiate(_viewPrefab);
        }

        public virtual void Open()
        {
            if (View == null) SpawnView();

            View.gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            View.gameObject.SetActive(false);
        }
    }
}