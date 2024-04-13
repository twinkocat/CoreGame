using twinkocat.UI.Interfaces;
using UnityEngine;

namespace twinkocat.UI.Entities
{
    public abstract class Presenter<TView> : IPresenter where TView : View
    {
        private TView _viewPrefab;
        private TView _viewInstance;
        
        public bool TryInjectViewComponent(View viewPrefab)
        {
            if (_viewPrefab is not null || viewPrefab is not TView tViewPrefab) return false;

            _viewPrefab = tViewPrefab;
            return true;
        }

        private TView SpawnView() => Object.Instantiate(_viewPrefab);

        public void Open(Transform parent = null)
        {
            if (_viewInstance == null)
            {
                _viewInstance = SpawnView();
                OnSpawnView(_viewInstance);
            }
            
            _viewInstance.transform.SetParent(parent);
            _viewInstance.gameObject.SetActive(true);
            OnOpen(_viewInstance);
        }
        
        public void Close()
        {
            _viewInstance.gameObject.SetActive(false);
            OnClose(_viewInstance);
        }
        
        protected virtual void OnSpawnView(TView view) { }
        protected virtual void OnOpen(TView view) { }
        protected virtual void OnClose(TView view) { }

        public virtual void Dispose()
        {
        }
    }
}