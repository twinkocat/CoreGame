// file ISequenceCommand.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

namespace twinkocat.Core.Sequencer
{
    public interface ISequenceCommand
    {
        virtual void Tick(float deltaTime) { }
        void Execute();
        bool IsCanBeExecute { get; }
    }
}