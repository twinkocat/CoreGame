// file MainMenuView.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.UI.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace twinkocat.Gameplay.UI.MainMenu
{
    public class MainMenuView : View
    {
        private MainMenuController _mainMenuController;
        
        [SerializeField] private Button loadGameButton;
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        public Button LoadGameButton => loadGameButton;
        public Button NewGameButton  => newGameButton;
        public Button SettingsButton => settingsButton;
        public Button ExitButton     => exitButton;
        
        private void Awake() =>_mainMenuController = new MainMenuController(this);
        private void OnDestroy() => _mainMenuController.Dispose();
    }
}