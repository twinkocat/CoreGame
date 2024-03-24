// file GameState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;

namespace twinkocat.Gameplay.GameStates
{
    public enum GameStateType
    {
        Default,
        CoolGame,
    }
    
    public abstract class GameState : IGameState
    {

        public static GameState CreateGame(GameStateType gameStateType)
        {
            return gameStateType switch
            {
                GameStateType.Default  => new DefaultGameState(),
                GameStateType.CoolGame => new CoolGameState(),

                _ => throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null)
            };
        }

        public abstract void Do();
        public virtual void Exit() { }
    }
}