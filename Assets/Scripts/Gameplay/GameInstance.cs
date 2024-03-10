// file GameInstance.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Interfaces;
using twinkocat.Core.Utilities;
using UnityEngine;

namespace twinkocat.Gameplay
{
    public interface IGameState : IState { }

    public interface IGameSubState : ISubState { }

    public class MenuState : IGameState
    {
        public void Do()
        {
            Debug.Log("do menu state");
            // MultipleSceneLoader.LoadScenes()
        }

        public void Exit()
        {
        }
    }
    
    public class PauseSubState : IGameSubState
    {
        public void DoSubState()
        {
            Debug.Log("pause");
        }
    }
    public class PlaySubState : IGameSubState
    {
        public void DoSubState()
        {
            Debug.Log("play");
        }
    }
    
    public class GameInstance : LazySingleton<GameInstance>, IStateMachine<IGameState, IGameSubState>
    {
        public IGameState     CurrentState     { get; private set; }
        public IGameSubState  CurrentSubState  { get; private set; }


        public void SetState(IGameState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Do();
        }

        public void SetSubState(IGameSubState newSubState)
        {
            CurrentSubState = newSubState;
            CurrentSubState.DoSubState();
        }
    }
}