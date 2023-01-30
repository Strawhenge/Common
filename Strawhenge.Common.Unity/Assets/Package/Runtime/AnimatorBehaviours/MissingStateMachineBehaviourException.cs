using System;

namespace Strawhenge.Common.Unity.AnimatorBehaviours
{
    public class MissingStateMachineBehaviourException : Exception
    {
        public MissingStateMachineBehaviourException(Type stateMachineBehaviourType)
            : base(message: $"Missing '{stateMachineBehaviourType.FullName}' from animator.")
        {
            StateMachineBehaviourType = stateMachineBehaviourType;
        }

        public Type StateMachineBehaviourType { get; }
    }
}