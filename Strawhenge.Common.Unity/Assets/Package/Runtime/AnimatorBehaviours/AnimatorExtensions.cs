using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.AnimatorBehaviours
{
    public static class AnimatorExtensions
    {
        public static StateMachineEvents<T> AddEvents<T>(
            this Animator animator,
            Action<T> subscribe,
            Action<T> unsubscribe)
            where T : StateMachineBehaviour, IHasDestroyedEvent =>
            new StateMachineEvents<T>(animator, subscribe, unsubscribe);
    }
}