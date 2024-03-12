using twinkocat.Core.UI.Interfaces;

namespace twinkocat.Core.UI
{
    public abstract class Presenter<TView> : IPresenter where TView : IView
    {
        protected TView View;
    }
    
    public abstract class Presenter<TView, TModel> : Presenter<TView> 
        where TView  : IView 
        where TModel : IModel
    {
        protected TModel Data;
    }
}