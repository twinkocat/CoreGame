// file IState.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Core.Interfaces
{
    public interface IState
    {
        void Start();
        void Do();
        void Exit();
    }
}