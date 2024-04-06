// file Sequencer.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using twinkocat.Core.Utilities;
using UnityEngine;

namespace twinkocat.Core.Sequencer
{
    public class Sequence
    {
        private bool _isRunning;
        private bool _isRepeatable;
        private Coroutine _sequenceRoutine;
        
        private readonly Queue<ISequenceCommand> _sequenceCommands = new();
        
        private Sequence() { }
        
        
        public static Sequence CreateSequence() => new();
        
        public Sequence AddCommand(ISequenceCommand sequenceCommand) => AddCommand_Internal(sequenceCommand);
        
        public Sequence SetDelay(int milliseconds) => AddCommand_Internal(new DelayedCommand(milliseconds));
        
        public Sequence StartSequence() => StartSequence_Internal();
        
        public Sequence Repeat(bool repeatable = true) => Repeat_Internal(repeatable);
        
        public void RunSequence()  => StartSequence_Internal();
        
        public void StopSequence() => Coroutines.StopCoroutine(_sequenceRoutine);
        
        public void ClearSequence() => _sequenceCommands.Clear();
        
        private Sequence Repeat_Internal(bool repeatable)
        {
            _isRepeatable = repeatable;
            return this;
        }
        
        private Sequence AddCommand_Internal(ISequenceCommand sequenceCommand)
        {
            _sequenceCommands.Enqueue(sequenceCommand);
            return this;
        }

        private Sequence StartSequence_Internal()
        {
            _sequenceRoutine = Coroutines.StartCoroutine(SequenceRoutine(_isRepeatable));
            return this;
        }

        private IEnumerator SequenceRoutine(bool repeatable)
        {
            do
            {
                var command = _sequenceCommands.Peek();
                command.Tick(Time.deltaTime);
                
                if (command.IsCanBeExecute)
                {
             
                    var executedCommand = _sequenceCommands.Dequeue();
                    executedCommand.Execute();
                
                    if (repeatable) 
                        _sequenceCommands.Enqueue(executedCommand);
                }
                
                yield return null;
                
            } while (!_sequenceCommands.IsEmpty());
        }
        
        private class DelayedCommand : ISequenceCommand
        {
            private readonly double _delayedSeconds;
            private float           _timeCounter;
        
            public DelayedCommand(int milliseconds) => _delayedSeconds = TimeSpan.FromMilliseconds(milliseconds).TotalSeconds;
            void ISequenceCommand.Tick(float deltaTime) => _timeCounter += deltaTime;
            bool ISequenceCommand.IsCanBeExecute => _timeCounter >= _delayedSeconds;
            void ISequenceCommand.Execute() => _timeCounter = 0;
        }
    }
}