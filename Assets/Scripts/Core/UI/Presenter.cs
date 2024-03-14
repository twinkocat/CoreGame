using twinkocat.Core.UI.Interfaces;

namespace twinkocat.Core.UI
{
    public abstract class Presenter<TView> : IPresenter where TView : IView
    {
        protected TView View;
    }
}