// file SettingsPresenter.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.UI.Entities;
using twinkocat.UI.Interfaces;

namespace twinkocat.Gameplay.UI.Settings
{
    public class SettingsWindow : Presenter<SettingsView>, IWindowPresenter
    {
        public WindowType WindowType => WindowType.Settings;
        public bool IsStackable => false;


        public void OpenWindow()
        {
            Open();
        }

        public void CloseWindow()
        {
            Close();
        }
    }
}