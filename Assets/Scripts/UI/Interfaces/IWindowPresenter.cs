// file IWindowPresenter.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Gameplay.UI;

namespace twinkocat.UI.Interfaces
{
    public interface IWindowPresenter : IPresenter
    {
        WindowType   WindowType  { get; }
        bool         IsStackable { get; }

        void OpenWindow();
        void CloseWindow();
    }
}