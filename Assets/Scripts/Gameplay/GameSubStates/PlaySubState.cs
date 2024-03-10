// file PlaySubState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using UnityEngine;

namespace twinkocat.Gameplay.GameSubStates
{
    public class PlaySubState : IGameSubState
    {
        public void DoSubState()
        {
            Debug.Log("play");
        }
    }
}