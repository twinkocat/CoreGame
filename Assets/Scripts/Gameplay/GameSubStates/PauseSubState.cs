// file PauseSubState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using UnityEngine;

namespace twinkocat.Gameplay.GameSubStates
{
    public class PauseSubState : IGameSubState
    {
        public void DoSubState()
        {
            Debug.Log("pause");
        }
    }
}