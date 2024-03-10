namespace twinkocat.Core.Interfaces
{
    public interface IStateMachine<TState> where TState : IState
    {
        TState     CurrentState     { get; }
        
        void SetState(TState newState);
    }

    public interface IStateMachine<TState, TSubState> : IStateMachine<TState> 
        where TState : IState 
        where TSubState : ISubState
    {
        TSubState  CurrentSubState  { get; }
        
        void SetSubState(TSubState newSubState);
    }
}