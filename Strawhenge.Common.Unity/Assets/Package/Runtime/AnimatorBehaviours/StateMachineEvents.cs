using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.AnimatorBehaviours
{
    /// <summary>
    /// Handles resubscribing to StateMachineBehaviour events when animator is reloaded.
    /// </summary>
    /// <typeparam name="T">The StateMachineBehaviour, which must implement IHasDestroyedEvent</typeparam>
    public class StateMachineEvents<T> where T : StateMachineBehaviour, IHasDestroyedEvent
    {
        readonly Animator _animator;
        readonly Action<T> _subscribe;
        readonly Action<T> _unsubscribe;

        T _stateMachine;

        public StateMachineEvents(Animator animator, Action<T> subscribe, Action<T> unsubscribe)
        {
            _animator = animator;
            _subscribe = subscribe;
            _unsubscribe = unsubscribe;
        }

        /// <summary>
        /// Acquires new StateMachineBehaviour and resubscribes events if previous one is destroyed. 
        /// </summary>
        /// <exception cref="MissingStateMachineBehaviourException">Throws if the StateMachineBehaviour is not found on the animator.</exception>
        public void PrepareIfRequired()
        {
            if (ReferenceEquals(_stateMachine, null))
            {
                _stateMachine = _animator.GetBehaviour<T>();

                if (_stateMachine == null)
                    throw new MissingStateMachineBehaviourException(typeof(T));

                _subscribe(_stateMachine);
                _stateMachine.Destroyed += OnStateMachineDestroyed;
            }
        }

        void OnStateMachineDestroyed()
        {
            _stateMachine.Destroyed -= OnStateMachineDestroyed;
            _unsubscribe(_stateMachine);
            _stateMachine = null;
        }
    }
}