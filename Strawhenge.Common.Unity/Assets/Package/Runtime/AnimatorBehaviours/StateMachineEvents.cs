using System;
using System.Collections.Generic;
using System.Linq;
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
        readonly List<T> _stateMachines = new List<T>();

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
            if (_stateMachines.Any())
                return;

            var stateMachines = _animator.GetBehaviours<T>();

            if (!stateMachines.Any())
                throw new MissingStateMachineBehaviourException(typeof(T));

            _stateMachines.AddRange(stateMachines);
            _stateMachines.ForEach(stateMachine =>
            {
                _subscribe(stateMachine);
                stateMachine.Destroyed += OnStateMachineDestroyed;
            });
        }

        void OnStateMachineDestroyed()
        {
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.Destroyed -= OnStateMachineDestroyed;
                _unsubscribe(stateMachine);
            }

            _stateMachines.Clear();
        }
    }
}