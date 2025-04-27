using FunctionalUtilities;
using UnityEngine;
using System;
using System.Collections;

namespace Strawhenge.Common.Unity
{
    public static class MonoBehaviourExtensions
    {
        public static Maybe<Coroutine> InvokeAsSoonAs(
            this MonoBehaviour monoBehaviour,
            Func<bool> condition,
            Action action)
        {
            if (condition())
            {
                action();
                return Maybe.None<Coroutine>();
            }

            return monoBehaviour.StartCoroutine(WaitUntilConditionMetCoroutine());

            IEnumerator WaitUntilConditionMetCoroutine()
            {
                yield return new WaitUntil(condition);
                action();
            }
        }
    }
}