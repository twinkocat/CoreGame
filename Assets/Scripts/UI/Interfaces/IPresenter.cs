using twinkocat.UI.Entities;

namespace twinkocat.UI.Interfaces
{
    public interface IPresenter
    {
        public bool TryInjectViewComponent(View viewPrefab);
    }
}