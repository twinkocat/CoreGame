// file SequenceCommand.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;
using twinkocat.Core.Utilities;

namespace twinkocat.Core.Sequencer
{
    public class SequenceCommand : ISequenceCommand
    {
        private readonly Action _action;

        public SequenceCommand(Action action) => _action = action;

        void ISequenceCommand.Tick(float deltaTime) { }

        public void Execute() => _action.SafeInvoke();

        bool ISequenceCommand.IsCanBeExecute => true;
    }
}