// file GameInstance.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.Interfaces;
using twinkocat.Core.Utilities;

namespace twinkocat.Gameplay
{
    public interface IGameState : IState { }

    public interface IGameSubState : ISubState { }

    public class GameInstance : LazySingleton<GameInstance>, IStateMachine<IGameState, IGameSubState>
    {
        public IGameState     CurrentState     { get; private set; }
        public IGameSubState  CurrentSubState  { get; private set; }


        public void SetState(IGameState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Start();
            CurrentState.Do();
        }

        public void SetSubState(IGameSubState newSubState)
        {
            CurrentSubState = newSubState;
            CurrentSubState.DoSubState();
        }
    }
}