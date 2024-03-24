// file MainMenuController.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Gameplay.GameStates;

namespace twinkocat.Gameplay.UI.MainMenu
{
    public class MainMenuController
    {
        private readonly MainMenuView _mainMenuView;

        public MainMenuController(MainMenuView menuView)
        {
            _mainMenuView = menuView;

            _mainMenuView.LoadGameButton.interactable = false;
            _mainMenuView.NewGameButton.onClick.AddListener(StartNewGame);
            _mainMenuView.SettingsButton.onClick.AddListener(OpenSettings);
            _mainMenuView.ExitButton.onClick.AddListener(ExitGame);
        }

        // private void LoadGame() => GameInstance.Instance.SetState(new GameState(/* load */));

        private void StartNewGame()
        {
            GameInstance.Instance.SetState(GameState.CreateGame(GameStateType.Default));
        }

        private void OpenSettings()
        {
            WindowManager.Instance.Open(WindowType.Settings);
        }

        private void ExitGame()
        {
            GameInstance.Instance.SetState(new ExitState());
        }

        public void Dispose()
        {
            _mainMenuView.LoadGameButton.onClick.RemoveAllListeners();
            _mainMenuView.NewGameButton.onClick.RemoveAllListeners();
            _mainMenuView.SettingsButton.onClick.RemoveAllListeners();
            _mainMenuView.ExitButton.onClick.RemoveAllListeners();
        }
    }
}