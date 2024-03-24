// file GameState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Gameplay.GameStates
{
    public abstract class GameState : IGameState
    {

        public static GameState CreateGame(/* static instance factory */)
        {
            switch (false)
            {
                //..
            }
            
            return new DefaultGameState();
        }

        public abstract void Do();


        public virtual void Exit() { }
    }
}